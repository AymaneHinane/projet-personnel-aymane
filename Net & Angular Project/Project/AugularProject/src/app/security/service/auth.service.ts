import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private accessTokenKey = 'access_token';
  private refreshTokenKey = 'refresh_token';
  private identity = 'identity';
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient,private router: Router) {
    this.loggedIn.next(this.isAuthenticated());
  }

  login(username: string, password: string): Observable<any> {
    return this.http.post('https://localhost:5037/api/authentication/login', {Username: username,Password: password });
  }

  saveTokens(tokens: { accessToken: string; refreshToken: string,identity:string }) {
    // Store tokens in local storage.
    console.log(tokens.accessToken);
    console.log(tokens.refreshToken)
    console.log(tokens.identity)
    localStorage.setItem(this.accessTokenKey, tokens.accessToken);
    localStorage.setItem(this.refreshTokenKey, tokens.refreshToken);
    localStorage.setItem(this.identity,tokens.identity);
    
     this.loggedIn.next(true);
     this.router.navigate(['/inventory/overview/rawMaterial']);
  }

  logout() {
    // Clear tokens and notify the application that the user has logged out.
    localStorage.removeItem(this.accessTokenKey);
    localStorage.removeItem(this.refreshTokenKey);
    localStorage.removeItem(this.identity);
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }

  isAuthenticated(): boolean {
    // Check if the user is authenticated based on the presence of the access token.
    return !!localStorage.getItem(this.accessTokenKey);
  }

  getIdentity():string{
    return localStorage.getItem(this.identity)??"";
  }

  getLoggedInStatus(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }

  refreshToken(): Observable<any> {

    const accessToken = localStorage.getItem(this.accessTokenKey);
    const refreshToken = localStorage.getItem(this.refreshTokenKey);
    console.log("refresh token");
    console.log(accessToken,refreshToken);

    return this.http.post('https://localhost:5037/api/authentication/refresh', { accessToken,refreshToken });
  }




}
