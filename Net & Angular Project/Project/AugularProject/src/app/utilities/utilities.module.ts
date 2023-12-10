import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AlertInfoComponent } from './alert-info/alert-info.component';
import { PagingComponent } from './paging/paging.component';





@NgModule({
  declarations: [
    AlertInfoComponent,
    PagingComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    AlertInfoComponent,
    PagingComponent
  ]
})
export class UtilitiesModule { }
