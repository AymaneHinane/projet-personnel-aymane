import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';



@Component({
  selector: 'app-history-manager',
  templateUrl: './history-manager.component.html',
  styleUrls: ['./history-manager.component.css']
})
export class HistoryManagerComponent implements OnInit{
     
  warehouseId:string|null=null;
  productCategory:string|null=null;

  constructor(private activedRouter:ActivatedRoute,private router: Router){
 
  }

  ngOnInit(): void {
    
    this.activedRouter.paramMap.subscribe(params=>{
      this.warehouseId = params.get("id");
      this.productCategory = params.get("productCategory");
      this.router.navigate([`warehouse/${this.warehouseId}/stockHistory/${this.productCategory}/stock`]);
    })


  }

  

}
