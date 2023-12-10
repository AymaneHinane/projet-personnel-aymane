import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RecipientTransferInfo, TransferOperationInfo } from '../Models/transfer.model';
import { TransferService } from '../Service/transfer.service';

@Component({
  selector: 'app-tranfer-details-management-table',
  templateUrl: './tranfer-details-management-table.component.html',
  styleUrls: ['./tranfer-details-management-table.component.css']
})
export class TranferDetailsManagementTableComponent implements OnInit {

  transferId?:string|null;
  transferOperationInfo:TransferOperationInfo[]=[]

  constructor(private activatedRoute:ActivatedRoute,private transferService:TransferService){

  }
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params=>{
      this.transferId = params.get('id');
    })

    if(this.transferId)
     this.transferService.getAllTransferOperation(this.transferId).subscribe((response:TransferOperationInfo[])=>{
       this.transferOperationInfo = response;
       
     },()=>{})
  }



  calculTransferStockTotal(recipientTransfer: RecipientTransferInfo[]) {
    return recipientTransfer.reduce((totalCount, curr) => totalCount + (curr.deliveredStock ?? 0), 0);
  }
  
  

}
