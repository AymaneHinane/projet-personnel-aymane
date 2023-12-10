import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-page-user',
  templateUrl: './admin-page-user.component.html',
  styleUrls: ['./admin-page-user.component.css']
})
export class AdminPageUserComponent implements OnInit {

  users:{id:string,username:string,role:string}[]=[];
  roles:{name:string}[]=[];

  roleSelected:string | null = null;

  userCreate:{
      firstname:string,
      lastname:string,
      username:string | null,
      password:string | null,
      email:string,
      phonenumber:string,
      roles:string[] | null
  }  = {
      firstname:"",
      lastname:"",
      username:null,
      password:null,
      email:"",
      phonenumber:"",
      roles:[]
  };

  constructor(private httpClient:HttpClient){
    
  }
  ngOnInit(): void {
    this.getAllUser();
    this.getAllRoles();
  }

  getAllUser(){
    this.httpClient.get<{id:string,username:string,role:string}[]>("https://localhost:5037/api/authentication/users").subscribe(response=>{
      console.log(response);
      this.users=response;
    })
  }

  getAllRoles(){
    this.httpClient.get<{name:string}[]>("https://localhost:5037/api/authentication/roles").subscribe(response=>{
      console.log(response);
      this.roles=response;
    })
  }

  addNewUser(){
     
    if(this.userCreate.username!=null && this.userCreate.password!=null&&this.roleSelected!=null){

      this.userCreate.roles!.push(this.roleSelected);
      console.log(this.userCreate);
      
      this.httpClient.post("https://localhost:5037/api/authentication",this.userCreate).subscribe(()=>{
        this.getAllUser();
      })
    }

  }

}
