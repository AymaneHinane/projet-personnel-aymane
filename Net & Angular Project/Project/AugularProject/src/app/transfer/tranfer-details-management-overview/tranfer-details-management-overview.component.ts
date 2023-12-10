import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TransferService } from '../Service/transfer.service';
import { TransferOverview } from '../Models/transfer.model';

@Component({
  selector: 'app-tranfer-details-management-overview',
  templateUrl: './tranfer-details-management-overview.component.html',
  styleUrls: ['./tranfer-details-management-overview.component.css']
})
export class TranferDetailsManagementOverviewComponent implements OnInit{
  
  transferId?:string|null;
  transferOverview?:TransferOverview;


  constructor(private activatedRoute:ActivatedRoute,private transferService:TransferService){

  }


  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params=>{
      this.transferId = params.get('id');

      if(this.transferId)
        this.transferService.transferOverview(this.transferId).subscribe((response)=>{
          this.transferOverview = response;
        },()=>{})
        })
  }


}
