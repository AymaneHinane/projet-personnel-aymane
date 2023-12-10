import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { AssignmentsComponent } from './assignments/assignments.component';
import { MatListModule } from '@angular/material/list';
import { GreenColorDirective } from './green-color.directive';
import { AssignmentsFormComponent } from './assignments-form/assignments-form.component';
import { FormsModule } from '@angular/forms';
import { UpdateAssignmentsformComponent } from './update-assignmentsform/update-assignmentsform.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatMenuModule} from '@angular/material/menu';
import {MatTabsModule} from '@angular/material/tabs';
import {MatTableModule} from '@angular/material/table';
import { AssignmentTableComponent } from './assignment-table/assignment-table.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { AuthInterceptor } from './auth.interceptor';
import { RegisterComponent } from './register/register.component';
import { MatOptionModule } from '@angular/material/core';
import { StudentTableComponent } from './student-table/student-table.component';
import { AssignmentInfoComponent } from './assignment-info/assignment-info.component';
import { MatCardModule } from '@angular/material/card';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SidebarComponent } from './sidebar/sidebar.component';

@NgModule({
  declarations: [
    AppComponent,
    AssignmentsComponent,
    GreenColorDirective,
    AssignmentsFormComponent,
    UpdateAssignmentsformComponent,
    AssignmentTableComponent,
    LoginComponent,
    RegisterComponent,
    StudentTableComponent,
    AssignmentInfoComponent,
    SidebarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    MatListModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatMenuModule,
    MatTabsModule,
    MatTableModule,
    HttpClientModule,
    MatOptionModule,
    MatIconModule,
    MatCardModule,
    MatSidenavModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
