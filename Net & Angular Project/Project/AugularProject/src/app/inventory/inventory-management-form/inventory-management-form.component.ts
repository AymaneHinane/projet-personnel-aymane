import { Component, ContentChild, ElementRef, EventEmitter, Input, OnInit, Output, QueryList, SimpleChanges, ViewChild, ViewChildren } from '@angular/core';
import { FinishedProductStock, RawMaterialStock, UpdateFinishedProductStock, UpdateRawMaterialStock } from '../Models/Stock.model';
import { InventoryService } from '../Service/inventory.service';
import { RefreshService } from 'src/app/utilities/Services/refresh.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-inventory-management-form',
  templateUrl: './inventory-management-form.component.html',
  styleUrls: ['./inventory-management-form.component.css']
})
export class InventoryManagementFormComponent  implements OnInit{


  @Input() rawMaterialStock?:RawMaterialStock;
  @Input() finishedProductStock?:FinishedProductStock;
  @Input() category:string | null = null;
  @ViewChildren('inputReset') inputElements!: QueryList<ElementRef<HTMLInputElement>>;



  newRawMaterialStock:UpdateRawMaterialStock = {    orderStock: null,deliverStock: null,consumeStock: null , transferedStockEntryTotal:null,transferedStockExitTotal:null};
  newFinishedProductStock:UpdateFinishedProductStock = { stockProduced:null,transferedStockExitTotal:null,};

  constructor(private route:ActivatedRoute,private inventoryService:InventoryService,private refreshService: RefreshService){}


  ngOnInit(): void {

      this.route.paramMap.subscribe(params=>{
          this.category = params.get('category')
        })
  }



  updateRawMaterialStock(property:string,value:string,operator:string){

      const currentValue = this.rawMaterialStock?.[property] ?? 0;
      const numericValue = Number(value); 
  
      if (operator === '+') {
        this.newRawMaterialStock = {
          ...this.newRawMaterialStock,
          [property]: Number(currentValue) + numericValue
        };
      } else if (operator === '-' && Number(currentValue) - numericValue >= 0 ) {
        this.newRawMaterialStock = {
          ...this.newRawMaterialStock,
          [property]: Number(currentValue) - numericValue
        };
      }
  }

  updateFinishedProductStock(property:string,value:string,operator:string){

    const currentValue = this.finishedProductStock?.[property] ?? 0;
    const numericValue = Number(value); 

    if (operator === '+') {
      this.newFinishedProductStock = {
        ...this.newFinishedProductStock,
        [property]: Number(currentValue) + numericValue
      };
    } else if (operator === '-' && Number(currentValue) - numericValue >= 0 ) {
      this.newFinishedProductStock = {
        ...this.newFinishedProductStock,
        [property]: Number(currentValue) - numericValue
      };
    }

}


ResetNewStock(stockType:string){
  if(stockType == 'rawMaterial')
  {
      this.newRawMaterialStock = {orderStock: null,deliverStock: null,consumeStock: null , transferedStockExitTotal:null,transferedStockEntryTotal:null};
  }
  else if(stockType == 'finishedProduct'){
      this.newFinishedProductStock = { stockProduced:null,transferedStockExitTotal:null};
  }

  this.resetAllInputValuesToZero();
  
  
}


resetAllInputValuesToZero() {
  this.inputElements.forEach(inputElement => {
    if (inputElement.nativeElement) {
      inputElement.nativeElement.value = '0';
    }
  });
}

UpdateRawMaterialStockDB()
{
  if(this.rawMaterialStock)
     this.inventoryService.updateRawMaterialStockStock(this.rawMaterialStock?.warehouseId,this.rawMaterialStock?.productId,this.newRawMaterialStock)
       .subscribe((response)=>{
          this.refreshService.refreshChildComponents();
     },()=>{})
}


UpdateFinishedProductStockDB()
{
  if(this.finishedProductStock)
     this.inventoryService.updateFinishedProductStock(this.finishedProductStock?.warehouseId,this.finishedProductStock?.productId,this.newFinishedProductStock)
       .subscribe((response)=>{
          this.refreshService.refreshChildComponents();
     },()=>{})
}


}
