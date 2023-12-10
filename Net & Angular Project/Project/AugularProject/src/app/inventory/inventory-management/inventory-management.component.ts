import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FinishedProductStock, RawMaterialStock } from '../Models/Stock.model';


@Component({
  selector: 'app-inventory-management',
  templateUrl: './inventory-management.component.html',
  styleUrls: ['./inventory-management.component.css']
})

export class InventoryManagementComponent {



  // warehouseId:string | null = null;
  // category:string | null = null;
  
  rawMaterialStock?:RawMaterialStock;
  finishedProductStock?:FinishedProductStock;

  constructor(private route:ActivatedRoute)
  {
    
  }

  ngOnInit(): void {
    //  this.route.paramMap.subscribe(params=>{
    //     this.warehouseId = params.get('id')
    //     this.category = params.get('category')
    //  }) 
  }



}
