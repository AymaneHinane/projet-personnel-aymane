import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { FinishedProductStock, RawMaterialStock, WarehouseFinishedProductStock, WarehouseRawMaterialStock } from '../Models/Stock.model';
import { ActivatedRoute } from '@angular/router';
import { InventoryService } from '../Service/inventory.service';
import { RefreshService } from 'src/app/utilities/Services/refresh.service';
import { checkLg } from 'ngx-bootstrap-icons';


@Component({
  selector: 'app-inventory-management-table',
  templateUrl: './inventory-management-table.component.html',
  styleUrls: ['./inventory-management-table.component.css']
})
export class InventoryManagementTableComponent {


  warehouseId:string | null = null;
  category:string | null = null;
  @Output() UpdateRawMaterialStockEvent:EventEmitter<RawMaterialStock> = new EventEmitter<RawMaterialStock>()
  @Output() UpdateFinishedProductStockEvent:EventEmitter<FinishedProductStock> = new EventEmitter<FinishedProductStock>()

  year:number =  new Date().getFullYear();

  rawMaterialStocks: WarehouseRawMaterialStock | null = null;
  finishedProductStock: WarehouseFinishedProductStock | null = null;


  constructor(private route:ActivatedRoute,private inventoryService:InventoryService,private refreshService: RefreshService)
  {
     this.refreshService.getRefreshObservable().subscribe(() => {
      if(this.warehouseId && this.category)
        this.getStock(this.warehouseId,this.category);
    });

  }


  ngOnInit(): void {

    this.route.paramMap.subscribe(params=>{
      this.warehouseId = params.get('id')
      this.category = params.get('category')

      if(this.warehouseId && this.category)
         this.getStock(this.warehouseId,this.category);

      if(this.category == 'rawMaterial')
        this.UpdateRawMaterialStockEvent.emit();
      else if(this.category === 'finishedProduct')
        this.UpdateFinishedProductStockEvent.emit();
   }) 

 }


 getStock(warehouseId:string,category:string){


  if (category === 'rawMaterial') {
    this.rawMaterialStocks = null;
    this.inventoryService.getRawMaterialStockStock(warehouseId).subscribe(
      (response:WarehouseRawMaterialStock)=>{
         this.rawMaterialStocks = response;
      },
      ()=>{}
      )
  } else if (category === 'finishedProduct') {
    this.finishedProductStock = null;
    this.inventoryService.getFinishedProductStock(warehouseId).subscribe(
      (response:WarehouseFinishedProductStock)=>{
         this.finishedProductStock = response;
      },
      (err)=>{
        console.log(err)
      }
      )
  }

}

 
UpdateRawMaterialStock(stock: RawMaterialStock) {
    this.UpdateRawMaterialStockEvent.emit(stock);
}


UpdateFinishedProductStock(stock: FinishedProductStock) {
   this.UpdateFinishedProductStockEvent.emit(stock);
}


AddNewProduct(npk:string){
   
   
  if(this.warehouseId)
    this.inventoryService.addNewProduct(this.warehouseId,{name:npk,category:'finishedProduct'}).subscribe(()=>{
      if(this.warehouseId && this.category)
        this.getStock(this.warehouseId, this.category);
    },()=>{})
}




}
