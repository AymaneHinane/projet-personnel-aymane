import { Component, ElementRef, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { RecipientTransferUpdate, TransferOperationInfo, TransferOperationUpdate } from '../Models/transfer.model';
import { VariableBinding } from '@angular/compiler';
import { TransferService } from '../Service/transfer.service';
import { NavigationStart, Router } from '@angular/router';
import { finalize, forkJoin } from 'rxjs';


@Component({
  selector: 'app-tranfer-details-management-update',
  templateUrl: './tranfer-details-management-update.component.html',
  styleUrls: ['./tranfer-details-management-update.component.css']
})
export class TranferDetailsManagementUpdateComponent implements OnInit {


  @Input() transferOperationInfo?:TransferOperationInfo;
  
  transferOperationUpdate?:TransferOperationUpdate = { 
    truckNumber:null,
    deliveryDate:null,
    shippedDate:null,
    exitStockWeight:null,
    entryStockWeight:null,
    transferStatus:null
  }

  recipientTransferUpdate?:RecipientTransferUpdate[] = [];
  pdfUpdate?:{file:FormData,type:string};
  @ViewChild('modal') modalElement!: ElementRef;


  constructor(private router: Router,private transferService:TransferService){
  }



  ngOnInit(): void {
    console.log(this.transferOperationInfo);
  }


   saveUpdateDB(){

    const apiCalls = [];
    
    if(this.transferOperationUpdate)  
      for(var key in this.transferOperationUpdate) //for(var key of Object.keys(this.transferOperationUpdate))
      {
        if(this.transferOperationUpdate[key] != null)
          apiCalls.push(this.transferService.updateTransferOperation(this.transferOperationInfo?.id!,this.transferOperationUpdate))
            
      }

    if(this.recipientTransferUpdate)
      if(this.recipientTransferUpdate.length > 0)
        apiCalls.push(this.transferService.updateRecipientTransfer(this.transferOperationInfo?.id!,this.recipientTransferUpdate))
         


    if(this.pdfUpdate)
        apiCalls.push(this.transferService.uploadPDF(this.transferOperationInfo?.id!,this.pdfUpdate.type,this.pdfUpdate.file))
       

    forkJoin(apiCalls)
    .pipe(
      finalize(() => {
        // This block of code will be executed when all API calls are completed (success or error)
        this.refreshComponent();
      })
    )
    .subscribe(
      (responses) => {
        // Handle the responses from the API calls if needed
        // responses is an array containing the responses from each API call
      },
      (error) => {
        // Handle any errors that occurred during API calls
        console.error('Error during API calls:', error);
      }
    );
       

  }


  refreshComponent() {
    const currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  
  
  UpdateTransferOperation(property:string,value:any){
    if(this.transferOperationUpdate)
     this.transferOperationUpdate[property] = value

    console.log(this.transferOperationUpdate);
  }

  convertToNumber(value:string){
      return Number(value);
  }

  UpdateRecipientTransferUpdateDto(recipientId:string,property:string,value:any){
    
    var index  = this.recipientTransferUpdate?.findIndex(x=>x.id == recipientId);

    if(index == -1)
    {
      var newRecipient:RecipientTransferUpdate = {id:recipientId,deliveredStock:null,transferStatus:null}
      newRecipient[property] = value;
      this.recipientTransferUpdate?.push(newRecipient)
    }else if(index !== -1){
      this.recipientTransferUpdate![index!][property] = value;
    }

  }


  uploadPDF(event: any,type:string){
    const file = event.target.files[0];
    const formData = new FormData();
    formData.append('file', file, file.name);
    this.pdfUpdate = {file:formData,type:type};
  }

}
