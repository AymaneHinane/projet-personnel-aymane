import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransferFormComponent } from './transfer-form/transfer-form.component';
import { TransferTableComponent } from './transfer-table/transfer-table.component';
import { TransferFilterComponent } from './transfer-filter/transfer-filter.component';
import { TransferManagementComponent } from './transfer-management/transfer-management.component';
import { FormsModule } from '@angular/forms';
import { TranferDetailsManagementComponent } from './tranfer-details-management/tranfer-details-management.component';
import { TranferDetailsManagementFormComponent } from './tranfer-details-management-form/tranfer-details-management-form.component';
import { TranferDetailsManagementTableComponent } from './tranfer-details-management-table/tranfer-details-management-table.component';
import { TranferDetailsManagementUpdateComponent } from './tranfer-details-management-update/tranfer-details-management-update.component';
import { PdfViewerComponent } from './pdf-viewer/pdf-viewer.component';
import { TranferDetailsManagementOverviewComponent } from './tranfer-details-management-overview/tranfer-details-management-overview.component';





@NgModule({
  declarations: [
    TransferFormComponent,
    TransferTableComponent,
    TransferFilterComponent,
    TransferManagementComponent,
    TranferDetailsManagementComponent,
    TranferDetailsManagementFormComponent,
    TranferDetailsManagementTableComponent,
    TranferDetailsManagementUpdateComponent,
    PdfViewerComponent,
    TranferDetailsManagementOverviewComponent,

  ],
  imports: [
    CommonModule,  FormsModule 
  ]
})
export class TransferModule { }
