import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Student } from '../student.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {


   student:Student = {
     _id:'',
     username :'',
     password : '',
     role : 'user'
   }


  constructor(private authService: AuthService) {}

  register(): void {
    this.authService.register(this.student.username, this.student.password, this.student.role).subscribe(
      () => {
        // Refresh the user table or perform any necessary actions
        console.log('User created successfully');
        // You can call a function to refresh the user table here
      },
      (error) => {
        console.error('Registration failed', error);
        // Handle registration error, e.g., display an error message to the user
      }
    );
  }

  



}
