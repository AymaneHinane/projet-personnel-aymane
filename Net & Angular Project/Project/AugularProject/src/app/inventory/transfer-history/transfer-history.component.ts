import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { Subscription, combineLatest, tap } from 'rxjs';
import { TransferHistory } from '../Models/history.model';
import { InventoryService } from '../Service/inventory.service';
import { HttpResponse } from '@angular/common/http';
import { FilterService } from 'src/app/utilities/Services/filter.service';

@Component({
  selector: 'app-transfer-history',
  templateUrl: './transfer-history.component.html',
  styleUrls: ['./transfer-history.component.css'],
 // providers:[FilterService]
})
export class TransferHistoryComponent implements OnInit,OnDestroy {

  warehouseId:string|null=null;
  transferCategory:string|null=null;
  productCategory:string|null=null;
  transferHistory:TransferHistory[]=[];
  private eventSubscription?: Subscription;

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
      this,this.inventoryService.getTransferHistory(this.warehouseId,this.productCategory).subscribe(
        (response:HttpResponse<TransferHistory[]>)=>{
          if(response.body){
            this.transferHistory = response.body;
            console.log(this.transferHistory);
          }
          this.filterService.addPaging(response.headers)
        })

      }


}
