import { Component } from '@angular/core';
import { ProductStock, ProductStockInfo } from '../Models/product.model';
import { InventoryService } from '../Service/inventory.service';
import { ActivatedRoute } from '@angular/router';
import { checkLg } from 'ngx-bootstrap-icons';
import { response } from 'express';

@Component({
  selector: 'app-inventory-overview',
  templateUrl: './inventory-overview.component.html',
  styleUrls: ['./inventory-overview.component.css']
})
export class InventoryOverviewComponent {

  productStockInfo:ProductStockInfo[]= [];
  year:number =  new Date().getFullYear();
  type?:string | null;
  finishedProductTotal:{stockProduced:number,cdaDeliverStock:number,remainingStock:number} = {stockProduced:0,cdaDeliverStock:0,remainingStock:0}

  excelFileUrl:string|null=null;

  constructor(private activatedRoute:ActivatedRoute,private inventoryService:InventoryService){

  }

  ngOnInit(): void {

    console.log("here");
    this.activatedRoute.paramMap.subscribe(params=>{
      this.type = params.get('type');
      console.log(this.type);
      this.productStockInfo = [];
      this.getData();
    })
  }

  getData(){
    if(this.type)
     this.inventoryService.getAllStock(this.type).subscribe((response:ProductStockInfo[])=>{
        console.log(response);
        this.productStockInfo = response;
        
        if(this.type == 'finishedProduct')
           this.TotalfinishedProductStock( this.productStockInfo)

        console.log(this.productStockInfo)
    },(err)=>{
        console.log(err)
    })
  }

  TotalfinishedProductStock(productStock:ProductStockInfo[]){
    this.finishedProductTotal.stockProduced  = productStock.reduce((sum,stock)=>sum+stock.stocks[0].stockProduced,0)
    this.finishedProductTotal.cdaDeliverStock  = productStock.reduce((sum,stock)=>sum+stock.stocks[0].transferedStockExitTotal,0)
    this.finishedProductTotal.remainingStock  = productStock.reduce((sum,stock)=>sum+stock.stocks[0].remainingStock,0)
  }

  calculateColumnSum(stocks: any[], property: string): number {
    return stocks.reduce((sum, stock) => sum + stock[property], 0);
  }
  
  downloadExcel(){
    this.inventoryService.downloadExcel().subscribe(blob=>{
      
      const url = window.URL.createObjectURL(blob);

      // Create an anchor element for downloading the file
      const a = document.createElement('a');
      a.href = url;
      a.download = 'StockData.xlsx';
      document.body.appendChild(a);
  
      // Trigger a click on the anchor element to initiate the download
      a.click();
  
      // Clean up the anchor and URL
      window.URL.revokeObjectURL(url);
      document.body.removeChild(a);
    });
    
  }

}
