import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderPageComponent } from './header-page/header-page.component';
import { AppRoutingModule } from '../app-routing.module';





@NgModule({
  declarations: [
    HeaderPageComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports:[
    HeaderPageComponent
  ]
})
export class HeadersModule { }
