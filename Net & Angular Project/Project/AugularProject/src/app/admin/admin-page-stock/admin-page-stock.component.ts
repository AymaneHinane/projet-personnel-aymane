import { Component } from '@angular/core';
import { WarehouseInfo } from 'src/app/inventory/Models/Warehouse.model';
import { InventoryService } from 'src/app/inventory/Service/inventory.service';

@Component({
  selector: 'app-admin-page-stock',
  templateUrl: './admin-page-stock.component.html',
  styleUrls: ['./admin-page-stock.component.css']
})
export class AdminPageStockComponent {


  warehousesInfo: WarehouseInfo[] = [];

  stockInitialize:{action:string|null,warehouseId:string|null,confirmed:boolean} = {action:null,warehouseId:null,confirmed:false};

  constructor(private inventoryService: InventoryService){
    this.inventoryService.getAllWarehouse("site").subscribe(
      (response:WarehouseInfo[]) => {
          this.warehousesInfo = response;
      },
      (error: any) => {
        console.error('An error occurred while fetching warehouses:', error);
      }
    );
  }


  applyChange(){
     if(this.stockInitialize.action!=null && this.stockInitialize.confirmed == true && this.stockInitialize.warehouseId!=null){
       if(this.stockInitialize.action == 'stockzero'){
        this.inventoryService.InitializeRawMaterialStock(this.stockInitialize.warehouseId).subscribe(()=>{})
       }else if(this.stockInitialize.action == 'newyear'){
        this.inventoryService.InitializeRawMaterialStockNewYear(this.stockInitialize.warehouseId).subscribe(()=>{})
       }
     }
  }
}
