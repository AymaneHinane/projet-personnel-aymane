import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { WarehouseInfo, WarehouseRegion } from '../Models/Warehouse.model';
import { Observable } from 'rxjs';
import { UpdateFinishedProductStock, UpdateRawMaterialStock, WarehouseFinishedProductStock, WarehouseRawMaterialStock } from '../Models/Stock.model';
import { AddProduct, ProductInfo, ProductStockInfo } from '../Models/product.model';
import { StockChangeHistory, TransferHistory } from '../Models/history.model';
import { FilterService } from 'src/app/utilities/Services/filter.service';



@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private _httpClient:HttpClient;
  private url:string  = "https://localhost:5037/api";

  constructor(private httpClient:HttpClient,private filterService:FilterService) { 
      this._httpClient = httpClient;
  }
   
  getAllWarehouse(category:string):Observable<WarehouseInfo[]> {
     return this._httpClient.get<WarehouseInfo[]>(`${this.url}/warehouse/category/${category}`)
  }

  getAllProduct(category:string):Observable<ProductInfo[]>{
     return this._httpClient.get<ProductInfo[]>(`${this.url}/product/${category}`);
  }

  getAllProductByWarehouseId(warehouseId:string,category:string):Observable<ProductInfo[]>{
     return this._httpClient.get<ProductInfo[]>(`${this.url}/product/warehouse/${warehouseId}/category/${category}`);
  }

  getRawMaterialStockStock(warehouseId:string):Observable<WarehouseRawMaterialStock>{
      return this._httpClient.get<WarehouseRawMaterialStock>(`${this.url}/warehouse/${warehouseId}/category/rawMaterial`)
  }

  getFinishedProductStock(warehouseId:string):Observable<WarehouseFinishedProductStock>{
    return this._httpClient.get<WarehouseFinishedProductStock>(`${this.url}/warehouse/${warehouseId}/category/finishedProduct`)
  }

  updateRawMaterialStockStock(warehouseId:string,productId:string,newStock:UpdateRawMaterialStock){
    console.log(warehouseId,productId,newStock)
     return this._httpClient.post<any>(`${this.url}/warehouse/${warehouseId}/category/rawProduct/product/${productId}`,newStock);
  }

  updateFinishedProductStock(warehouseId:string,productId:string,newStock:UpdateFinishedProductStock){
    console.log(warehouseId,productId,newStock)
    return this._httpClient.post<any>(`${this.url}/warehouse/${warehouseId}/category/finishedProduct/product/${productId}`,newStock);
  }

  getAllStock(type:string):Observable<ProductStockInfo[]>{
     return this._httpClient.get<ProductStockInfo[]>(`${this.url}/product/stock/category/${type}`);
  }

  addNewProduct(warehouseId:string,addProduct:AddProduct){
    return this._httpClient.post<any>(`${this.url}/warehouse/${warehouseId}/product/add`,addProduct);
  }

  getAllWarehouseByRegion():Observable<WarehouseRegion[]>{
    return this._httpClient.get<WarehouseRegion[]>(`${this.url}/warehouse/regions`);
 }


  getStockChangeHistory(warehouseId:string,productCategory:string):Observable<HttpResponse<StockChangeHistory[]>>{
    console.log(this.filterService.filter);
    return this._httpClient.get<StockChangeHistory[]>(`${this.url}/warehouse/${warehouseId}/stockChangeHistory?category=${productCategory}`,{params:this.filterService.filter!, observe: 'response' })
  }

  getTransferHistory(warehouseId:string,productCategory:string):Observable<HttpResponse<TransferHistory[]>>{
    return this._httpClient.get<TransferHistory[]>(`${this.url}/warehouse/${warehouseId}/transferHistory?category=${productCategory}`,{params:this.filterService.filter!,observe: 'response' });
  }

  getDeliveryHistory(warehouseId:string,productCategory:string):Observable<HttpResponse<TransferHistory[]>>{
    return this._httpClient.get<TransferHistory[]>(`${this.url}/warehouse/${warehouseId}/deliveryHistory?category=${productCategory}`,{params:this.filterService.filter!, observe: 'response' });
  }

  downloadExcel():Observable<Blob>{
    return this._httpClient.get(`${this.url}/product/finishedProduct/excel`, { responseType: 'blob' });
  }

  InitializeRawMaterialStock( warehouseId:string){
    return this._httpClient.get(`${this.url}/warehouse/${warehouseId}/initialize`);
  }

  InitializeRawMaterialStockNewYear( warehouseId:string){
    return this._httpClient.get(`${this.url}/warehouse/${warehouseId}/initializeNewYear`);
  }

  
}
