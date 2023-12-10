import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AdminPageStockComponent } from './admin-page-stock/admin-page-stock.component';
import { AdminPageUserComponent } from './admin-page-user/admin-page-user.component';
import { AppRoutingModule } from '../app-routing.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AdminPageComponent,
    AdminPageStockComponent,
    AdminPageUserComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    FormsModule
  ]
})
export class AdminModule { }
