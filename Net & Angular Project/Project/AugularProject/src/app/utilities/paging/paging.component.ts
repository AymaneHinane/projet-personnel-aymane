
import { Component, OnInit } from '@angular/core';

import { PaginationInfo } from 'src/app/transfer/Models/transfer.model';
import { FilterService } from '../Services/filter.service';
import { ActivatedRoute, NavigationEnd, NavigationStart, Router } from '@angular/router';


@Component({
  selector: 'app-paging',
  templateUrl: './paging.component.html',
  styleUrls: ['./paging.component.css']
})
export class PagingComponent implements OnInit{
   

   paginationInfo:PaginationInfo|null=null;

   constructor(private filterService:FilterService,private router: Router, private route: ActivatedRoute){

   }

   ngOnInit(): void {

    this.route.queryParamMap.subscribe((queryParams) => {
        this.paginationInfo = this.filterService.paginationInfo;
    });

    
   }

    goToPage(page: number): void {

    if(this.paginationInfo)
      if (page >= 1 && page <= this.paginationInfo.totalPages && page !== this.paginationInfo.currentPage) {

         this.filterService.updatePagging(page);
      }
    }
    
    get hasPreviousPage(): boolean {
      if(this.paginationInfo)
        return this.paginationInfo.currentPage > 1;
      return false;
    }
    
    get hasNextPage(): boolean {
      if(this.paginationInfo)
        return this.paginationInfo.currentPage < this.paginationInfo.totalPages;
      return false;
    }


}

