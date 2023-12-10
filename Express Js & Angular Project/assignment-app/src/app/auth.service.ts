import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = 'http://localhost:3000'; // Update with your API endpoint
  private jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    console.log("hello");
    return this.http.post<any>(`${this.baseUrl}/login`, { username, password });
  }

  register(username: string, password: string, role: string): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/register`, { username, password, role });
  }

  setToken(token: string): void {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return token ? !this.jwtHelper.isTokenExpired(token) : false;
  }

  getRole(): string | null {
    const token = this.getToken();
    return token ? this.jwtHelper.decodeToken(token).role : null;
  }

  clearToken(): void {
    localStorage.removeItem('token');
  }



}
