import { Component, OnDestroy, OnInit } from '@angular/core';
import { TransferHistory } from '../Models/history.model';
import { HttpResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { InventoryService } from '../Service/inventory.service';
import { FilterService } from 'src/app/utilities/Services/filter.service';

@Component({
  selector: 'app-delivery-history',
  templateUrl: './delivery-history.component.html',
  styleUrls: ['./delivery-history.component.css']
})
export class DeliveryHistoryComponent implements OnInit,OnDestroy {
  
  warehouseId:string|null=null;
  transferCategory:string|null=null;
  productCategory:string|null=null;
  transferHistory:TransferHistory[]=[];


  constructor(private route:ActivatedRoute, private router: Router,private inventoryService:InventoryService,private filterService:FilterService){

  }


  ngOnDestroy(): void {
    console.log("onDestroy");
    this.filterService.updatePagging(1)
  }


  ngOnInit(): void {

    this.route.parent!.paramMap.subscribe(params=>{
      this.warehouseId = params.get('id');
      this.productCategory = params.get('productCategory');
      this.filterService.updatePagging(1);
      this.getData();
    })
    
     this.route.queryParamMap.subscribe((queryParams) => {
         this.getData();
    });
}
  

getData(){

      if(this.productCategory && this.warehouseId)
        this,this.inventoryService.getDeliveryHistory(this.warehouseId,this.productCategory).subscribe(
        (response:HttpResponse<TransferHistory[]>)=>{
          if(response.body){
            this.transferHistory = response.body;
            console.log(this.transferHistory);
          }
          this.filterService.addPaging(response.headers)
        })
      }

}
