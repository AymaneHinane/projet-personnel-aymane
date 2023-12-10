import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InventoryModule} from './inventory/inventory.module';
import 'bootstrap/dist/js/bootstrap.min.js';

import { HeadersModule } from './headers/headers.module';


import { UtilitiesModule } from './utilities/utilities.module';
import { InventoryService } from './inventory/Service/inventory.service';
import { AlertServiceService } from './utilities/Services/alert-service.service';
import { RefreshService } from './utilities/Services/refresh.service';
import { TransferModule } from './transfer/transfer.module';
import { ChargeModule } from './charge/charge.module';
import { SecurityModule } from './security/security.module';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from './security/service/auth.guard';
import { AuthService } from './security/service/auth.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './security/service/auth.interceptor';
import { AdminModule } from './admin/admin.module';





@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    InventoryModule,
    HeadersModule,
    AppRoutingModule,
    UtilitiesModule,
    TransferModule,
    ChargeModule,
    SecurityModule,
    AdminModule,
    FormsModule
  ],
  providers: [InventoryService,AlertServiceService,RefreshService,
    AuthGuard,
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor, 
      multi: true,
    },],
  bootstrap: [AppComponent]
})
export class AppModule { }
