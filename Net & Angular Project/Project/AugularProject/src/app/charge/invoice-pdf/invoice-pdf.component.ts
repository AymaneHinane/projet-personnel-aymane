import { Component, Input, OnInit } from '@angular/core';
import { InvoiceService } from '../Service/invoice.service';
import { InvoicePdf } from '../Model/invoice.models';
import { checkLg } from 'ngx-bootstrap-icons';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-invoice-pdf',
  templateUrl: './invoice-pdf.component.html',
  styleUrls: ['./invoice-pdf.component.css']
})
export class InvoicePdfComponent implements OnInit{

   
  @Input() invoiceId:string | null = null;
  invoicePdf:SafeUrl | null = null;

  constructor(private invoiceService:InvoiceService,private sanitizer: DomSanitizer){
    
  }

  ngOnInit(): void {

   

   
  }

  getInvoice(){
     if(this.invoiceId)
     this.invoiceService.getInvoicePdf(this.invoiceId).subscribe(
      (data) => {
        console.log(data);
        // Convert ArrayBuffer to a safe URL
        const blob = new Blob([data], { type: 'application/pdf' }); // Adjust the content type as needed
        this.invoicePdf = this.sanitizer.bypassSecurityTrustResourceUrl(window.URL.createObjectURL(blob));
    })
  }

}
