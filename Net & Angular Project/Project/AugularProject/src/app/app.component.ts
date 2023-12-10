import { Component, OnInit } from '@angular/core';
import { AuthService } from './security/service/auth.service';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  loggedIn:boolean=false;
  identity:string|null=null;

  constructor(private authService:AuthService)
  {
    
  }

  ngOnInit(): void {
     this.authService.getLoggedInStatus().subscribe(value=>{
      this.loggedIn=value
      this.identity=this.authService.getIdentity();
    });


     console.log(this.identity);
  }

  logout(){
    this.authService.logout();
  }
}
