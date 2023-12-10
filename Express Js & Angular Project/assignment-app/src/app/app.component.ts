import { Component } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'assignment-app';

  constructor(private authService: AuthService,private router: Router){
    
  }


  logout(): void {
    console.log('logout');
    this.authService.clearToken();
    this.router.navigate(['']); // Redirect to the login page after logout
  }

}
