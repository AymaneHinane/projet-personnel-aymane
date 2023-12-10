import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoiceService } from '../Service/invoice.service';
import { InvoiceInfo } from '../Model/invoice.models';
import { HttpResponse } from '@angular/common/http';
import { FilterService } from 'src/app/utilities/Services/filter.service';


@Component({
  selector: 'app-invoice-table',
  templateUrl: './invoice-table.component.html',
  styleUrls: ['./invoice-table.component.css'],
})
export class InvoiceTableComponent implements OnInit,OnDestroy {

  warehouseId:string|null=null;
  invoices:InvoiceInfo[]|null=null;

  constructor(private route:ActivatedRoute,private invoiceService:InvoiceService,private filterService:FilterService){

  }


  ngOnDestroy(): void {
    console.log("onDestroy");
    this.filterService.updatePagging(1)
  }


  ngOnInit(): void {

    this.route.paramMap.subscribe(params=>{
      this.warehouseId = params.get("id");
      this.filterService.updatePagging(1);      
      this.getInvoice();
    })

    this.initialiseFilter();

    this.route.queryParamMap.subscribe((queryParams) => {
      this.getInvoice();
    });
  
  }


  getInvoice(){
    if(this.warehouseId){
     this.invoiceService.getAllInvoice(this.warehouseId).subscribe(
       (response: HttpResponse<InvoiceInfo[]>) => {

        this.invoices = response.body
        
        this.filterService.addPaging(response.headers);
    })
  }
     
  }


  initialiseFilter(){
    var filter=[
      {
        property:"category",
        propertyName:"categorie",
        value:null,
      },
      {
        property:"numero",
        propertyName:"numero",
        value:null,
      },
      {
        property:"date",
        propertyName:"date",
        value:null,
      },
      {
        property:"pageNumber",
        propertyName:"",
        value:null,
      },
      {
        property:"pageSize",
        propertyName:"",
        value:null,
      },
    ]
  
    
  }




}
