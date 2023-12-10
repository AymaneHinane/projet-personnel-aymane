import { Component, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { TransferFilter, TransferFilterApplied } from '../Models/transfer.model';
import { InventoryService } from 'src/app/inventory/Service/inventory.service';
import { WarehouseInfo, WarehouseRegion } from 'src/app/inventory/Models/Warehouse.model';
import { ProductInfo } from 'src/app/inventory/Models/product.model';
import { TransferService } from '../Service/transfer.service';
import { ActivatedRoute } from '@angular/router';
import { response } from 'express';
import { TransferFilterService } from '../Service/transfer-filter.service';


@Component({
  selector: 'app-transfer-filter',
  templateUrl: './transfer-filter.component.html',
  styleUrls: ['./transfer-filter.component.css']
})

export class TransferFilterComponent implements OnInit,OnChanges {

  PageSelected?:string;

  warehouseId:string | null = null;

  WarehouseList?:WarehouseInfo[];
  RecipientDcRegionList?:WarehouseRegion[]=[] 

  rawMaterialSite?:ProductInfo[];
  rawMaterialAll?:ProductInfo[];

  finishedProductSite?:ProductInfo[]; 
  finishedProductAll?:ProductInfo[]; 

  regionSelected?:string;

  transferFilter?:TransferFilter|null;
  transferFilterApplied:TransferFilterApplied[]=[];


  constructor(private transferFilterService:TransferFilterService,private route:ActivatedRoute,private transferService:TransferService,private inventoryService:InventoryService)
  {
    
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(this.PageSelected);
  }

  ngOnInit(): void {

    this.route.paramMap.subscribe(params=>{
      this.warehouseId = params.get('id')
    }) 

    this.transferFilterService.getPageSelected().subscribe((page: string) => {
      this.PageSelected = page;
    });

    this.transferFilterService.getTransferFilter().subscribe((result)=>{
      this.transferFilter = result;
    },()=>{})

    this.transferFilterService.getTransferFilterApplied().subscribe(result=>{
      this.transferFilterApplied = result;
    },()=>{})

    this.getData();
  }

  getData(){
    this.inventoryService.getAllWarehouse("site").subscribe((response)=>{
      this.WarehouseList = response;
    },()=>{})
  
    if(this.warehouseId)
    {
     this.inventoryService.getAllProductByWarehouseId(this.warehouseId,"rawMaterial").subscribe((response)=>{
       this.rawMaterialSite = response;
     },()=>{})

     this.inventoryService.getAllProductByWarehouseId(this.warehouseId,"finishedProduct").subscribe((response)=>{
       this.finishedProductSite = response;
     },()=>{})
    }

    this.inventoryService.getAllWarehouseByRegion().subscribe((response)=>{
      this.RecipientDcRegionList = response;
    })

    this.inventoryService.getAllProduct("rawMaterial").subscribe((response)=>{
      this.rawMaterialAll = response;
    })

    this.inventoryService.getAllProduct("finishedProduct").subscribe((response)=>{
      this.finishedProductAll = response;
    })
  }

  getDcByregion(region:string){
    return this.RecipientDcRegionList?.filter(x=>x.warehouseRegion == region)[0].warehouseInfo;
  }

  updateTransferFilter(property:string,target:any){

    console.log('delay()');
    if(target == null){
      this.transferFilterService.updateTransferFilter(property, null)
      return;
    }

    if(this.PageSelected)
     if(property == 'numero' || property == 'qte'){
       this.transferFilterService.updateTransferFilter(property, Number(target.value))
     }else{
       this.transferFilterService.updateTransferFilter(property,target.value)
     }
  }
  
}
