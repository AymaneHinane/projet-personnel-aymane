import { Component, OnDestroy, OnInit } from '@angular/core';
import { TransferService } from '../Service/transfer.service';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-pdf-viewer',
  templateUrl: './pdf-viewer.component.html',
  styleUrls: ['./pdf-viewer.component.css']
})
// export class PdfViewerComponent {

// }


export class PdfViewerComponent implements OnInit , OnDestroy{

  pdfUrl?:SafeResourceUrl;
  transferOperationId?:string | null;
  voucherType?:string | null;


  constructor(private activatedRoute:ActivatedRoute,private transferService: TransferService,private sanitizer: DomSanitizer) { }

  ngOnInit(): void {

    this.activatedRoute.paramMap.subscribe(params=>{
       this.transferOperationId = params.get('id');
       this.voucherType = params.get('type');
    })
    this.getPdfFile();
  }

  getPdfFile(): void {
    if (this.transferOperationId && this.voucherType) {
      this.transferService.getPdf(this.transferOperationId, this.voucherType).subscribe(
        (pdfBlob: Blob) => {
          this.pdfUrl = this.sanitizer.bypassSecurityTrustResourceUrl(URL.createObjectURL(pdfBlob));
        },
        (error) => {
          console.error('Error fetching PDF:', error);
        }
      );
    }
  }


  ngOnDestroy(): void {
    if (this.pdfUrl) {
      //URL.revokeObjectURL(this.pdfUrl);
    }
  }
}