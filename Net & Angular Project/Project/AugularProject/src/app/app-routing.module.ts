import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InventoryManagementComponent } from './inventory/inventory-management/inventory-management.component';
import { InventoryOverviewComponent } from './inventory/inventory-overview/inventory-overview.component';
import { TransferManagementComponent } from './transfer/transfer-management/transfer-management.component';
import { TranferDetailsManagementComponent } from './transfer/tranfer-details-management/tranfer-details-management.component';
import { PdfViewerComponent } from './transfer/pdf-viewer/pdf-viewer.component';
import { InvoiceManagerComponent } from './charge/invoice-manager/invoice-manager.component';
import { StockHistoryComponent } from './inventory/stock-history/stock-history.component';
import { HistoryManagerComponent } from './inventory/history-manager/history-manager.component';
import { TransferHistoryComponent } from './inventory/transfer-history/transfer-history.component';
import { LoginComponent } from './security/login/login.component';
import { AuthGuard } from './security/service/auth.guard';
import { DeliveryHistoryComponent } from './inventory/delivery-history/delivery-history.component';
import { AdminPageComponent } from './admin/admin-page/admin-page.component';
import { AdminPageStockComponent } from './admin/admin-page-stock/admin-page-stock.component';
import { AdminPageUserComponent } from './admin/admin-page-user/admin-page-user.component';


const routes: Routes = [
  {path:"inventory/overview/:type",component:InventoryOverviewComponent,canActivate: [AuthGuard] },
   {path:"inventory/:id/:category",component:InventoryManagementComponent,canActivate: [AuthGuard] },
   {path:"transfer/:id",component:TransferManagementComponent, canActivate: [AuthGuard]},
   {path:"transfer/:id/transferDetails",component:TranferDetailsManagementComponent, canActivate: [AuthGuard]},
   {path:"transferOperation/:id/voucher/:type",component:PdfViewerComponent, canActivate: [AuthGuard]},
   {path:"warehouse/:id/invoice",component:InvoiceManagerComponent, canActivate: [AuthGuard]},
   {path:"warehouse/:id/stockHistory/:productCategory",component:HistoryManagerComponent, canActivate: [AuthGuard],
    children:[
      {
        path:"stock",component:StockHistoryComponent
      },
      {
        path:"transfer",component:TransferHistoryComponent
      },
      {
        path:"delivery",component:DeliveryHistoryComponent
      }
    ]
  },
  {path:"login",component:LoginComponent},
  {path:"admin",component:AdminPageComponent,canActivate: [AuthGuard],
   children:[
    {path:'stock',component:AdminPageStockComponent},
    {path:'user',component:AdminPageUserComponent}
   ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
