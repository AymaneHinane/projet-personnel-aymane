import { Component, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TransferService } from '../Service/transfer.service';
import { PaginationInfo, TransferInfo, TransferUpdate } from '../Models/transfer.model';
import { HttpHeaders, HttpResponse } from '@angular/common/http';
import { WarehouseInfo } from 'src/app/inventory/Models/Warehouse.model';
import { RefreshService } from 'src/app/utilities/Services/refresh.service';
import { TransferFilterService } from '../Service/transfer-filter.service';

@Component({
  selector: 'app-transfer-table',
  templateUrl: './transfer-table.component.html',
  styleUrls: ['./transfer-table.component.css']
})
export class TransferTableComponent {

  warehouseId:string | null = null;

  pageSelected:string = 'transfer';

  transfers: TransferInfo[] = [];

  paginationInfo:PaginationInfo = { 
    currentPage: 1,
    totalPages: 0,
    pageSize: 15,
    totalCount: 0
  }

  transferQueryFilter:string='';

  showTranferForm:boolean=false;


  constructor(private transferFilterService:TransferFilterService,private route:ActivatedRoute,private transferService:TransferService,private refreshService: RefreshService) {

  }

  ngOnInit(): void {

    this.route.paramMap.subscribe(params=>{
      this.warehouseId = params.get('id')
      this.GetTransfers();
    }) 

    this.transferFilterService.getPageSelected().subscribe((result)=>{
       this.pageSelected = result;
       this.paginationInfo.currentPage=1;
       this.refreshService.getRefreshObservable().subscribe(() => {
        this.GetTransfers();
      })
    },()=>{})

    this.transferFilterService.getTransferFilterQuery().subscribe((result)=>{
      this.transferQueryFilter = result;
      this.GetTransfers();
    },()=>{})

  }

  UpdateSelectedPage(page:string){

    this.showTranferForm = false;
    this.transferFilterService.updateSelectedPage(page);
    this.GetTransfers();

  }

  GetTransfers(){



        if(this.warehouseId) {

          var transferMethod;

          if(this.pageSelected == 'transfer')
              transferMethod = this.transferService.getTransfersByWarehouseId(this.warehouseId,this.paginationInfo,this.transferQueryFilter);
          else if(this.pageSelected =  'delivery')
              transferMethod = this.transferService.getDeliveriesByWarehouseId(this.warehouseId,this.paginationInfo,this.transferQueryFilter);
        
     
          if(transferMethod)
           transferMethod.subscribe(
             (response: HttpResponse<TransferInfo[]>) => {
     
              console.log(response);
               if(response.body != null)
               {
                this.transfers = response.body;
                console.log(this.transfers);
     
                const headers: HttpHeaders = response.headers;
                const xPaginationHeader: string | null = headers.get('X-Pagination');
         
                if (xPaginationHeader) {
                   const xPaginationData = JSON.parse(xPaginationHeader);
                   this.paginationInfo.currentPage = xPaginationData.CurrentPage;
                   this.paginationInfo.totalPages = xPaginationData.TotalPages;
                   this.paginationInfo.pageSize = xPaginationData.PageSize;
                   this.paginationInfo.totalCount = xPaginationData.TotalCount;
                 }
                }
             },
             (error) => {
               
             })
        }
      }



      goToPage(page: number): void {

        if (page >= 1 && page <= this.paginationInfo.totalPages && page !== this.paginationInfo.currentPage) {
          this.paginationInfo.currentPage = page;
          this.GetTransfers();
        }
      }
      
      get hasPreviousPage(): boolean {
        return this.paginationInfo.currentPage > 1;
      }
      
      get hasNextPage(): boolean {
        return this.paginationInfo.currentPage < this.paginationInfo.totalPages;
      }


      shippedConfirm(transferId:string,stock:number){

         var shipped:TransferUpdate = {
          transferedStockQuantity:null,
          deliveredStockQuantity:stock,
          transferStatus:"shipped"
      }

         this.transferService.updateTransfer(transferId,shipped).subscribe(()=>{
           this.GetTransfers();
         });
      }
}
