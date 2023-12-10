import { EventEmitter, Injectable } from '@angular/core';
import { PaginationInfo } from 'src/app/transfer/Models/transfer.model';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from '../Models/filter.model';


@Injectable({
  providedIn: 'root'
})
export class FilterService {

  paginationInfo:PaginationInfo = { 
    currentPage: 1,
    totalPages: 0,
    pageSize: 15,
    totalCount: 0
  }

  public filter:HttpParams|null=null; 

  constructor( private route: ActivatedRoute,private router: Router) { }

  addPaging(headers: HttpHeaders){

    const xPaginationHeader: string | null = headers.get('X-Pagination');
         
    if (xPaginationHeader) {
       const xPaginationData = JSON.parse(xPaginationHeader);
       this.paginationInfo.currentPage = xPaginationData.CurrentPage;
       this.paginationInfo.totalPages = xPaginationData.TotalPages;
       this.paginationInfo.pageSize = xPaginationData.PageSize;
       this.paginationInfo.totalCount = xPaginationData.TotalCount;
     }

    this.router.navigate([], {
      relativeTo: this.route, 
      queryParams: { pageNumber: this.paginationInfo.currentPage, pageSize: this.paginationInfo.pageSize },
      queryParamsHandling: 'merge', 
    });

    this.route.queryParamMap.subscribe((queryParams) => {
          this.filter =  new HttpParams();

          this.filter = this.filter!.set("pageNumber", this.paginationInfo.currentPage);
          this.filter = this.filter!.set("pageSize", this.paginationInfo.pageSize);
    })

  }


  updatePagging(currentPage:number):Promise<boolean>{

    this.paginationInfo.currentPage = currentPage;

    var promise = this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { pageNumber: this.paginationInfo.currentPage, pageSize: this.paginationInfo.pageSize },
      queryParamsHandling: 'merge',
    });

    this.route.queryParamMap.subscribe((queryParams) => {
      this.filter =  new HttpParams();

      this.filter = this.filter!.set("pageNumber", this.paginationInfo.currentPage);
      this.filter = this.filter!.set("pageSize", this.paginationInfo.pageSize);
    })


   return promise;
    
  }


  addFilter(filter:filter[]){
    
    var filterObject:{ [key: string] : any }  = {};
    
    for(var property of filter){
      filterObject[property.property] = property.value;
    }

    console.log(filterObject);


    var promise = this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { pageNumber: this.paginationInfo.currentPage, pageSize: this.paginationInfo.pageSize,...filterObject},
      queryParamsHandling: 'merge',
    });

    this.route.queryParamMap.subscribe((queryParams) => {
      this.filter =  new HttpParams();

      this.filter = this.filter!.set("pageNumber", this.paginationInfo.currentPage);
      this.filter = this.filter!.set("pageSize", this.paginationInfo.pageSize);

      for(var property of filter){
        this.filter = this.filter!.set(property.property, property.value);
      }

    })

  }

}


