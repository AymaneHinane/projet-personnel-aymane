import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { InvoiceCategory, InvoiceInfo, InvoiceInsert, InvoicePdf } from '../Model/invoice.models';
import { Observable } from 'rxjs';
import { FilterService } from 'src/app/utilities/Services/filter.service';


@Injectable()
export class InvoiceService{
  
  private url:string = "https://localhost:5037/api" 


  constructor(private _httpClient:HttpClient,private filterService:FilterService) { 

  }


  public getInvoiceCategory():Observable<InvoiceCategory[]>{
      return this._httpClient.get<InvoiceCategory[]>(`${this.url}/charge/invoiceCategory`);
  }

  public postInvoice(invoiceInsert:FormData){
    return this._httpClient.post(`https://localhost:5037/api/charge/invoice`,invoiceInsert);
  }

  public getAllInvoice(id:string):Observable<HttpResponse<InvoiceInfo[]>>{
    console.log(this.filterService.filter);
    
     return this._httpClient.get<InvoiceInfo[]>(
             `${this.url}/charge/invoices/${id}`,
             { params:this.filterService.filter!,observe: 'response' }
          );
  }

  public getInvoicePdf(id:string):Observable<ArrayBuffer>{
    return this._httpClient.get(`${this.url}/charge/invoice/${id}/pdf`,{ responseType: 'arraybuffer' });
  }

}
