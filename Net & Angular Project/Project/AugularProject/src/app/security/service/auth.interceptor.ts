import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, filter, finalize, switchMap, take, throwError } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  
  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const accessToken = localStorage.getItem('access_token');

    if (accessToken) {
      request = this.addTokenToRequest(request, accessToken);
    }

    return next.handle(request).pipe(
      catchError((error) => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          return this.handle401Error(request, next);
        }
        return throwError(error);
      })
    );

  }

  private addTokenToRequest(
    request: HttpRequest<any>,
    token: string
  ): HttpRequest<any> {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
  }

  private handle401Error(request: HttpRequest<any>,next: HttpHandler): Observable<HttpEvent<any>> {

    if (!this.isRefreshing) {

      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return this.authService.refreshToken().pipe(
        switchMap((newTokens) => {

          this.isRefreshing = false;
          console.log("this.refreshTokenSubject.next(newTokens)");
          console.log(newTokens);
          console.log(newTokens.accessToken);
          console.log(newTokens.refreshToken);
          console.log(newTokens.identity);
          this.refreshTokenSubject.next(newTokens);
          this.authService.saveTokens({ accessToken: newTokens.accessToken,refreshToken: newTokens.refreshToken,identity:newTokens.identity} )
          return next.handle(this.addTokenToRequest(request, newTokens.accessToken));
        }),
        catchError((error) => {
          this.authService.logout(); // Logout the user if token refresh fails.
          return throwError(error);
        })
      );

    } else {

      // If a refresh token request is already in progress, wait until it's completed.
      return this.refreshTokenSubject.pipe(
        filter((tokens) => tokens !== null),
        take(1),
        switchMap((tokens) => {
          return next.handle(this.addTokenToRequest(request, tokens.access_token));
        })
      );

    }
  }


}
