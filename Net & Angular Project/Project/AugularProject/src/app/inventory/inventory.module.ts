import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { InventoryManagementComponent } from './inventory-management/inventory-management.component';
import { InventoryManagementTableComponent } from './inventory-management-table/inventory-management-table.component';
import { InventoryManagementFormComponent } from './inventory-management-form/inventory-management-form.component';
import { InventoryOverviewComponent } from './inventory-overview/inventory-overview.component';
import { StockHistoryComponent } from './stock-history/stock-history.component';
import { TransferHistoryComponent } from './transfer-history/transfer-history.component';
import { HistoryManagerComponent } from './history-manager/history-manager.component';
import { AppRoutingModule } from '../app-routing.module';
import { UtilitiesModule } from "../utilities/utilities.module";
import { FilterService } from '../utilities/Services/filter.service';
import { DeliveryHistoryComponent } from './delivery-history/delivery-history.component';






@NgModule({
    declarations: [
        InventoryManagementComponent,
        InventoryManagementFormComponent,
        InventoryManagementTableComponent,
        InventoryOverviewComponent,
        StockHistoryComponent,
        TransferHistoryComponent,
        HistoryManagerComponent,
        DeliveryHistoryComponent
    ],
    exports: [],
    imports: [
        CommonModule,
        HttpClientModule,
        AppRoutingModule,
        UtilitiesModule
    ],
    //providers:[FilterService]
})

export class InventoryModule { }
