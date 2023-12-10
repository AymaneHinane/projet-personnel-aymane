import { Component, OnInit} from '@angular/core';
import { TransferService } from '../Service/transfer.service';
import { Recipient, TransferInsert } from '../Models/transfer.model';
import { InventoryService } from 'src/app/inventory/Service/inventory.service';
import { ProductInfo } from 'src/app/inventory/Models/product.model';
import { WarehouseInfo, WarehouseRegion } from 'src/app/inventory/Models/Warehouse.model';
import { ActivatedRoute, Router } from '@angular/router';
import { RefreshService } from 'src/app/utilities/Services/refresh.service';
import { AlertServiceService } from 'src/app/utilities/Services/alert-service.service';
import { AlertInfoType } from 'src/app/utilities/alert-info/alertInfoType.enum';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-transfer-form',
  templateUrl: './transfer-form.component.html',
  styleUrls: ['./transfer-form.component.css']
})

export class TransferFormComponent implements OnInit {

  warehouseId:string | null = null;

  transferInsert:TransferInsert = {SenderId:null,Recipients:[],ProductId:null,TransferedStockQuantity:null,DestinationType:null}
  WarehouseInfo?:WarehouseInfo[];
  rawMaterial?:ProductInfo[];
  finishedProduct?:ProductInfo[]; 
  destination?:string;
  TransferRegion?:WarehouseRegion[] = [];
  DestributionCenters?:WarehouseInfo[] = [];

  dcNotSelected?:boolean = true ;


  constructor(private router:Router,private activatedRoute:ActivatedRoute,private transferService:TransferService,private inventoryService:InventoryService,private refreshService: RefreshService,private alertServiceService:AlertServiceService) {
       
  }

  ngOnInit(): void {

    console.log("form");

    this.activatedRoute.paramMap.subscribe(params=>{
      this.warehouseId = params.get('id')
   }) 

    this.inventoryService.getAllWarehouse("site").subscribe((response)=>{
       this.WarehouseInfo = response;
    },()=>{})
   
    if(this.warehouseId)
    {
      this.inventoryService.getAllProductByWarehouseId(this.warehouseId,"rawMaterial").subscribe((response)=>{
        this.rawMaterial = response;
        
      },()=>{})

      this.inventoryService.getAllProductByWarehouseId(this.warehouseId,"finishedProduct").subscribe((response)=>{
        this.finishedProduct = response;
        
      },()=>{})

      this.inventoryService.getAllWarehouseByRegion().subscribe((response)=>{
         this.TransferRegion = response;
      })
    }
  }



  UpdateTransferInsert(property:string,target:any){

     if(property != 'Recipients')   
        this.transferInsert[property] = property!='TransferedStockQuantity'?target.value:Number(target.value);
      else{
        this.transferInsert.Recipients!.push({RecipientId:target.value});
      }

  }

    ResetForm(destination:any){
    this.destination = destination.value;
    this.transferInsert = {SenderId:null,Recipients:[],ProductId:null,TransferedStockQuantity:null,DestinationType:null}
  }

  AddNewTransfer()
  {
    //this.transferInsert.Recipients!.length > 0  &&
    if( this.transferInsert.ProductId != null && this.transferInsert.TransferedStockQuantity !=null)
    {

      this.transferInsert.SenderId = this.warehouseId; 
      this.transferInsert.DestinationType = this.destination!;

      this.transferService.addNewTransfer(this.transferInsert).subscribe(()=>{
      this.destination = 'menu';
      this.transferInsert = {SenderId:null,Recipients:[],ProductId:null,TransferedStockQuantity:null,DestinationType:null}
      this.refreshService.refreshChildComponents();
      
      // this.router.navigate(['form'],{relativeTo:this.activatedRoute}) //transfer/:id
      //this.router.navigate([`transfer/${this.warehouseId}`])
      },(error:HttpErrorResponse)=>{
        console.log(error);
        console.log(AlertInfoType.danger);
        this.alertServiceService.showAlertInfo({message:error.status+' '+error.error.Message,alertType:AlertInfoType.danger,iSvisible:true});
      })
    }else{
      
    }

  }

  GetDestributionCenters(target:any){

    this.DestributionCenters = this.TransferRegion?.filter(x=>x.warehouseRegion == target.value)[0].warehouseInfo; 
  }


  getDcRecipientName(id:string){

      for(let warehouse of this.TransferRegion!)
      {
           for(let region of warehouse.warehouseInfo)
              if(region.id == id)
                 return region.name; 
      }

      return null;
  }


  getSiteRecipientName(id:string){
   
    if(this.WarehouseInfo)
       var name = this.WarehouseInfo.find(element => element.id == id)?.name;
    
    return name;
  }

  deleteRecipient(id:string){

     var newRecipients = this.transferInsert.Recipients?.filter(x=>x.RecipientId != id);

    if(newRecipients)
       this.transferInsert.Recipients = newRecipients;
  }


}


