import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AssignmentsComponent } from './assignments/assignments.component';
import { RegisterComponent } from './register/register.component';
import { AssignmentInfoComponent } from './assignment-info/assignment-info.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: AssignmentsComponent },
  { path: 'register', component: RegisterComponent },
  { path:'assignment-info/:id',component:AssignmentInfoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
