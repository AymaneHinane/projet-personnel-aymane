import { Component } from '@angular/core';
import { WarehouseInfo } from 'src/app/inventory/Models/Warehouse.model';
import { InventoryService } from 'src/app/inventory/Service/inventory.service';
import { AuthService } from 'src/app/security/service/auth.service';



@Component({
  selector: 'app-header-page',
  templateUrl: './header-page.component.html',
  styleUrls: ['./header-page.component.css']
})
export class HeaderPageComponent {
  
  warehousesInfo: WarehouseInfo[] = [];
  warehouseId:string|null=null;
  identity:string | null = null;

  constructor(private inventoryService: InventoryService,private authService:AuthService) {}

  ngOnInit(): void {

    this.inventoryService.getAllWarehouse("site").subscribe(
      (response:WarehouseInfo[]) => {
        this.identity = this.authService.getIdentity();
        if(this.authService.getIdentity() == 'ADMIN')
          this.warehousesInfo = response;
        else
          this.warehousesInfo = response.filter(x=>x.name == this.authService.getIdentity())

      },
      (error: any) => {
        console.error('An error occurred while fetching warehouses:', error);
      }
    );

    console.log(this.authService.getIdentity());
  }
}
