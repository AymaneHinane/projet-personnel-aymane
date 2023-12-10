import { Component, OnInit } from '@angular/core';
import { InvoiceCategory, InvoiceInsert } from '../Model/invoice.models';
import { InvoiceService } from '../Service/invoice.service';
import { ActivatedRoute } from '@angular/router';
import { checkLg } from 'ngx-bootstrap-icons';
//import { InventoryService } from 'src/app/inventory/Service/inventory.service';


@Component({
  selector: 'app-invoice-form',
  templateUrl: './invoice-form.component.html',
  styleUrls: ['./invoice-form.component.css']
})
export class InvoiceFormComponent implements OnInit {

  formData: InvoiceInsert = {
    InvoiceNumber: '',
    Excl_taxes: '',
    Incl_taxes: '',
    InvoicePdf: null, // Initialize to null; will be updated when a file is selected
    InvoiceCategoryId: '',
    WarehouseId: ''
  };

  
  

  private warehouseId?:string|null  = null;
  invoiceCategory?:InvoiceCategory[];

  constructor(  private activatedRoute:ActivatedRoute , 
    // private inventoryService: InventoryService,
     private invoiceService:InvoiceService)
     {

  }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((params)=>{
      this.warehouseId = params.get("id");

      if(this.warehouseId)
        this.formData.WarehouseId = this.warehouseId;
    })

    this.invoiceService.getInvoiceCategory().subscribe((response: InvoiceCategory[]) => {
      this.invoiceCategory = [...response];
     //console.log(this.invoiceCategory);

      this.formData.InvoiceCategoryId="choisiser une category";
    });
    

  }

  onFileChange(event: any) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      this.formData.InvoicePdf = fileList[0];
    }
  }

  // convertFormDataToInvoiceInsert(formData: FormData): InvoiceInsert {
  //   return {
  //     InvoiceNumber: formData.get('InvoiceNumber') as string,
  //     Excl_taxes: formData.get('Excl_taxes') as string,
  //     Incl_taxes: formData.get('Incl_taxes') as string,
  //     InvoicePdf: formData.get('InvoicePdf') as string | File,
  //     InvoiceCategoryId: formData.get('InvoiceCategoryId') as string,
  //     WarehouseId: formData.get('WarehouseId') as string
  //   };
  // }

  
  submitForm(){

   // console.log(this.formData);

    const formData = new FormData();
    formData.append('InvoiceNumber', this.formData.InvoiceNumber);
    formData.append('Excl_taxes',this.formData.Excl_taxes);
    formData.append('Incl_taxes', this.formData.Incl_taxes);

    if(this.formData.InvoicePdf)
      formData.append('InvoicePdf', this.formData.InvoicePdf,this.formData.InvoicePdf.name);

    formData.append('InvoiceCategoryId', this.formData.InvoiceCategoryId);
    formData.append('WarehouseId', this.formData.WarehouseId);

    this.invoiceService.postInvoice(formData).subscribe((response)=>{
      console.log(response)
    },err=>{
      console.log(err)
    })


  }


}
