import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoiceManagerComponent } from './invoice-manager/invoice-manager.component';
import { FormsModule } from '@angular/forms';
import { InvoiceFormComponent } from './invoice-form/invoice-form.component';
import { InvoiceTableComponent } from './invoice-table/invoice-table.component';
import { InvoicePdfComponent } from './invoice-pdf/invoice-pdf.component';
import { InvoiceFilterComponent } from './invoice-filter/invoice-filter.component';
import { InvoiceService } from './Service/invoice.service';
import { UtilitiesModule } from '../utilities/utilities.module';






@NgModule({
  declarations: [
    InvoiceManagerComponent,
    InvoiceFormComponent,
    InvoiceTableComponent,
    InvoicePdfComponent,
    InvoiceFilterComponent,
    
  ],
  imports: [
    CommonModule,FormsModule,UtilitiesModule
  ],
  providers:[InvoiceService]
})
export class ChargeModule { }
