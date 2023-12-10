import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginationInfo, RecipientInfo, TransferInfo, TransferInsert, TransferOperationInfo, TransferOperationInsert,TransferOperationUpdate,RecipientTransferUpdate, TransferOverview, TransferUpdate } from '../Models/transfer.model';
import { Observable } from 'rxjs';
import { WarehouseRegion } from 'src/app/inventory/Models/Warehouse.model';


@Injectable({
  providedIn: 'root'
})
export class TransferService {

  private url:string = "https://localhost:5037/api" 

  constructor(private _httpClient: HttpClient) { }
    
  addNewTransfer(transferInsert:TransferInsert):Observable<any>{
     return this._httpClient.post(`${this.url}/transfer`,transferInsert);
  }

  updateTransfer(transferId:string,transferUpdate:TransferUpdate):Observable<any>{
    return this._httpClient.put(`${this.url}/transfer/${transferId}`,transferUpdate);
  }

  getTransfersByWarehouseId(warehouseId:string,paginationInfo:PaginationInfo,filter:string): Observable<HttpResponse<TransferInfo[]>>{
      return this._httpClient.get<TransferInfo[]>(`${this.url}/warehouse/${warehouseId}/transfers?pageNumber=${paginationInfo.currentPage}&pageSize=${paginationInfo.pageSize}&${filter}`,{ observe: 'response' });
  }

  getDeliveriesByWarehouseId(warehouseId:string,paginationInfo:PaginationInfo,filter:string): Observable<HttpResponse<TransferInfo[]>>{
    return this._httpClient.get<TransferInfo[]>(`${this.url}/warehouse/${warehouseId}/deliveries?pageNumber=${paginationInfo.currentPage}&pageSize=${paginationInfo.pageSize}&${filter}`,{ observe: 'response' });
  }

  getRecipientByTransferId(transferId:string):Observable<RecipientInfo[]>{
    return this._httpClient.get<RecipientInfo[]>(`${this.url}/transfer/${transferId}/recipients`);
  }


  addNewTransferOperation(transferId:string,transferDetailsInsert:TransferOperationInsert):Observable<any>{
    return this._httpClient.post(`${this.url}/transfer/${transferId}/delivery`,transferDetailsInsert);
  }

  getAllTransferOperation(transferId:string):Observable<TransferOperationInfo[]>{
    return this._httpClient.get<TransferOperationInfo[]>(`${this.url}/transfer/${transferId}/transferoperation`)
  }

  getPdf(id:string,voucher:string): Observable<Blob> {
    return this._httpClient.get(`${this.url}/transferOperation/${id}/voucher/${voucher}`, { responseType: 'blob' });
  }

  updateTransferOperation(transferOperationId:string,transferOperationUpdate:TransferOperationUpdate):Observable<any>{
     return this._httpClient.put(`${this.url}/transferOperation/${transferOperationId}`,transferOperationUpdate)
  }

  updateRecipientTransfer(transferOperationId:string,recipientTransferUpdate:RecipientTransferUpdate[]):Observable<any>{
    return this._httpClient.put(`${this.url}/transferOperation/${transferOperationId}/recipient`,recipientTransferUpdate)
  }

  uploadPDF(id: string, type: string, file: FormData):Observable<any>{
    return this._httpClient.post(`${this.url}/transferOperation/${id}/voucher/${type}`,file);
  }

  transferOverview(id:string){
    return this._httpClient.get<TransferOverview>(`${this.url}/transfer/${id}`)
  }


}
