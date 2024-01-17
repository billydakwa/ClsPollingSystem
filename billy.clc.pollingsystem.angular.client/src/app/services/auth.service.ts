import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl: string = 'https://localhost:7075/api/';
  constructor(private http: HttpClient, private router: Router) {}

  signUp(user: any) {
    return this.http.post<any>(`${this.baseUrl}User/register`, user);
  }

  login(user: any) {
    return this.http.post<any>(`${this.baseUrl}User/authenticate`, user);
  }

  signOut() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  tokenStorage(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isLoggedIn() {
    var tk = jwtDecode(this.getToken()!) as any;
    return !!(this.getToken() && tk.exp < Date.now());
  }
}
