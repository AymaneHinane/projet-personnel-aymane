import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TransferService } from '../Service/transfer.service';
import { RecipientInfo, RecipientTransferInsert, TransferOperationInsert } from '../Models/transfer.model';
import { cloudDownload } from 'ngx-bootstrap-icons';

@Component({
  selector: 'app-tranfer-details-management-form',
  templateUrl: './tranfer-details-management-form.component.html',
  styleUrls: ['./tranfer-details-management-form.component.css']
})
export class TranferDetailsManagementFormComponent  implements OnInit{

  transferId:string | null = null;
  recipientInfo:RecipientInfo[] = [];
  transferOperationInsert:TransferOperationInsert={TruckNumber:null,ExitStockWeight:null,RecipientTransfers:[]};

  constructor(private router: Router,private activatedRoute:ActivatedRoute,private transferService:TransferService){

  }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params=>{
      this.transferId = params.get('id');

     if(this.transferId)
      this.transferService.getRecipientByTransferId(this.transferId).subscribe((response)=>{
          this.recipientInfo = response;
      },()=>{});

   }) 
  }

  refreshComponent() {
    const currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  

  addTransferOperation(){

    if(this.transferId && this.transferOperationInsert)
    {
      if(this.transferOperationInsert.TruckNumber != null && this.transferOperationInsert.ExitStockWeight != null && this.transferOperationInsert.ExitStockWeight > 0 && this.transferOperationInsert.RecipientTransfers?.length! > 0 && this.verifyIfAllRecipientHaveQte(this.transferOperationInsert.RecipientTransfers)){

        console.log(this.transferOperationInsert);

        this.transferService.addNewTransferOperation(this.transferId,this.transferOperationInsert).subscribe(()=>{
           this.refreshComponent();
        },()=>{})
      }
    }

  }

  addNewTransferDetails(property:string,value:any){

    if(this.transferOperationInsert)
      this.transferOperationInsert[property]= value;

  }

  updateRecipientSelected(id:string,selected:boolean){

    console.log(id,selected);

    var index = this.transferOperationInsert?.RecipientTransfers?.findIndex(x=>x.RecipientId==id);

    if(selected)
       if(index == -1)
         this.transferOperationInsert?.RecipientTransfers?.push({RecipientId:id,DeliveredStock:0});


    if(!selected){
        this.transferOperationInsert.RecipientTransfers = this.transferOperationInsert?.RecipientTransfers?.filter(x=>x.RecipientId != id);
    }

    console.log(this.transferOperationInsert);

  }

  updateRecipientQuantity(id:string,qte:number){

    var index = this.transferOperationInsert?.RecipientTransfers?.findIndex(x=>x.RecipientId==id);

    if(this.transferOperationInsert.RecipientTransfers && index != -1)
    {
       var recipient = this.transferOperationInsert.RecipientTransfers[index];
       if(recipient)
           this.transferOperationInsert.RecipientTransfers[index].DeliveredStock = qte;
    }

  }

  convertToNumber(value:string){
    return Number(value);
  }

  ifRecipientSelcted(id:string){
     return this.transferOperationInsert.RecipientTransfers?.findIndex(x=>x.RecipientId == id)
  }

  getRecipientSelected(id:string){
    return this.transferOperationInsert.RecipientTransfers.find(x=>x.RecipientId == id)
  }

  verifyIfAllRecipientHaveQte(recipients:RecipientTransferInsert[]) :boolean{
     return recipients.every(x=>x.DeliveredStock > 0)
  }




}
