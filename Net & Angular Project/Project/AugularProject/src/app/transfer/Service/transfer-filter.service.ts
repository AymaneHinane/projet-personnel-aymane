import { Injectable } from '@angular/core';
import { TransferFilter, TransferFilterApplied } from '../Models/transfer.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransferFilterService {

  private transferFilterSender:TransferFilter = {
    numero:null,
    sender:null,
    recipient:null,
    status:null,
    recipientType:null,
    region:null,
    product:null,
    qte:null,
    deliveryDate:null,
    shippedDate:null
  }

  private transferFilterRecipient:TransferFilter = {
    numero:null,
    sender:null,
    recipient:null,
    status:null,
    recipientType:null,
    region:null,
    product:null,
    qte:null,
    deliveryDate:null,
    shippedDate:null
  }

  private filterNameDictionnary:{dbPropertyName:string,filterPropertyName:string}[] = [
    {dbPropertyName:'numero',filterPropertyName:'numero'},
    {dbPropertyName:'sender',filterPropertyName:'depuis'},
    {dbPropertyName:'recipient',filterPropertyName:'vers'},
    {dbPropertyName:'status',filterPropertyName:'statut'},
    {dbPropertyName:'recipientType',filterPropertyName:'type de destinataire'},
    {dbPropertyName:'region',filterPropertyName:'region'},
    {dbPropertyName:'product',filterPropertyName:'produit'},
    {dbPropertyName:'qte',filterPropertyName:'quantite'},
    {dbPropertyName:'deliveryDate',filterPropertyName:'date de transfert'},
    {dbPropertyName:'shippedDate',filterPropertyName:'date de livraison'},
  ]

  
  private pageSelected:string ='transfer';
  private transferFilterSubject = new BehaviorSubject<TransferFilter|null>(this.transferFilterRecipient);
  private pageSelectedSubject = new BehaviorSubject<string>('transfer');
  private transferQueryFilterSubject = new BehaviorSubject<string>('');
  private transferFilterAppliedSubject = new BehaviorSubject<TransferFilterApplied[]>([]);


  constructor() { }

  updateTransferFilter(property:string,value:string|number|null){

    console.log(this.pageSelected,property,value);

      if(this.pageSelected == 'transfer')
      {
        this.transferFilterSender = {...this.transferFilterSender,[property]:value};
        this.transferFilterSubject.next( this.transferFilterSender);
      }
      else if(this.pageSelected == 'delivery')
      {
        this.transferFilterRecipient = {...this.transferFilterRecipient,[property]:value};
        this.transferFilterSubject.next( this.transferFilterRecipient);
      }

      console.log(this.transferFilterSubject.value);

      this.updateTransferFilterQuery();
      this.updateTransferFilterApplied();
  }

  updateTransferFilterApplied(){


          var filter  = Object.keys(this.transferFilterSubject.value!)
             .filter(x=>this.transferFilterSubject.value![x]!=null)
             .map(x=>{
               var filterPropertyName = this.filterNameDictionnary.filter(y=>y.dbPropertyName == x)[0].filterPropertyName;
               var value = this.transferFilterSubject.value![x] ?? '';

               return {
                filterProperty:x,
                filterPropertyName:filterPropertyName,
                value : value !== null && typeof value !== 'string' ? String(value) : value
               }
             })


          this.transferFilterAppliedSubject.next(filter);

  }


  updateSelectedPage(pageSelected:string){

    if(pageSelected == 'transfer')
    {
      this.transferFilterSubject.next(this.transferFilterSender);
    }
    else if(pageSelected == 'delivery')
    {
      this.transferFilterSubject.next(this.transferFilterRecipient);
    }

    this.pageSelected = pageSelected;
    this.pageSelectedSubject.next(this.pageSelected);

    this.updateTransferFilterQuery();
    this.updateTransferFilterApplied();


  }


  getPageSelected(){

    return this.pageSelectedSubject.asObservable();
  }


  updateTransferFilterQuery(){

    if(this.transferFilterSubject.value)
      this.transferQueryFilterSubject.next(Object.keys(this.transferFilterSubject.value).filter(x=>this.transferFilterSubject.value![x]!=null).reduce((som,x:string)=>som+`${x}=${this.transferFilterSubject.value![x]}&`,'')); 
  }

  getTransferFilter(){
    return this.transferFilterSubject.asObservable();
  }



  getTransferFilterQuery(){
    return this.transferQueryFilterSubject.asObservable();
  }

  getTransferFilterApplied(){
    return this.transferFilterAppliedSubject.asObservable();
  }


}
