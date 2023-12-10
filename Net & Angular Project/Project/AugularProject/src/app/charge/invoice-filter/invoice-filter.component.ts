import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';

import { InvoiceCategory } from '../Model/invoice.models';
import { InvoiceService } from '../Service/invoice.service';
import { filter } from 'src/app/utilities/Models/filter.model';
import { checkLg } from 'ngx-bootstrap-icons';
import { FilterService } from 'src/app/utilities/Services/filter.service';

@Component({
  selector: 'app-invoice-filter',
  templateUrl: './invoice-filter.component.html',
  styleUrls: ['./invoice-filter.component.css'],
 // providers:[]
})
export class InvoiceFilterComponent implements OnInit {

  invoiceCategory:InvoiceCategory[] | null = null;
  filter:filter[] = []
  categoryValue: any = null; // Separate property for the category input
  numeroValue: any = null;

  constructor(private invoiceService:InvoiceService,private filterService:FilterService){

  }

  ngOnInit(): void {
    this.invoiceService.getInvoiceCategory().subscribe((response)=>{
        this.invoiceCategory = response;
    })
  }


  updateFilter(property: string, data: any) {

    if(property=="category")
      this.filter.push({property:property,propertyName:null,value:data.value});//this.filterService.updateFilter(property, data.value);
    else
      this.filter.push({property:property,propertyName:null,value:data});

    this.filterService.addFilter(this.filter);
  }

}
