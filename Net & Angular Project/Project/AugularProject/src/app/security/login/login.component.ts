import { Component } from '@angular/core';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  username: string = '';
  password: string = '';

  constructor(private authService: AuthService) {}

  login() {
    this.authService.login(this.username, this.password).subscribe(
      (response) => {
        // Save tokens and navigate to a protected route.
        console.log(response);
        this.authService.saveTokens(response);
        // Redirect to a protected route.
      },
      (error) => {
        console.error('Login failed:', error);
      }
    );
  }
  
}
