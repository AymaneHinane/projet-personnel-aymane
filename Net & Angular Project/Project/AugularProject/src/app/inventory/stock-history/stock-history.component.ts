import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { InventoryService } from '../Service/inventory.service';
import { createKeywordTypeNode } from 'typescript';
import { HttpResponse } from '@angular/common/http';
import { StockChangeHistory } from '../Models/history.model';
import { Subscription } from 'rxjs';
import { FilterService } from 'src/app/utilities/Services/filter.service';

@Component({
  selector: 'app-stock-history',
  templateUrl: './stock-history.component.html',
  styleUrls: ['./stock-history.component.css'],
 // providers:[FilterService]
})
export class StockHistoryComponent implements OnInit,OnDestroy{

  warehouseId:string|null=null;
  productCategory:string|null=null;
  stockChangeHistories:StockChangeHistory[]=[]

  constructor(private route:ActivatedRoute, private router: Router,private inventoryService:InventoryService,private filterService:FilterService){

  }

  ngOnDestroy(): void {
    console.log("onDestroy");
    this.filterService.updatePagging(1)
  }

  ngOnInit(): void {

    // this.router.events.forEach((event) => {
    //   if(event instanceof NavigationStart) {
    //     this.filterService.updatePagging(1)
    //   }
    // });

    this.route.parent!.paramMap.subscribe(params=>{
      this.warehouseId = params.get('id');
      this.productCategory = params.get('productCategory');
      this.filterService.updatePagging(1)
      // this.getData();
    })

    this.route.queryParamMap.subscribe((queryParams) => {
        console.log(queryParams.get("pageNumber"));
        this.getData();
    });

  }

  getData(){
    console.log(this.warehouseId,this.productCategory);
    if(this.warehouseId && this.productCategory)
    this.inventoryService.getStockChangeHistory(this.warehouseId,this.productCategory).subscribe(
      (response:HttpResponse<StockChangeHistory[]>)=>{
        if(response.body){
           this.stockChangeHistories = response.body;
        }

        this.filterService.addPaging(response.headers)

      })

     
  }






}
