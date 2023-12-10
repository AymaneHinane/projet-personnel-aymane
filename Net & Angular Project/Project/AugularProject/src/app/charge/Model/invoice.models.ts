

export interface InvoiceInsert{
    InvoiceNumber:string
    Excl_taxes:string
    Incl_taxes:string
    InvoicePdf: File | null
    InvoiceCategoryId:string
    WarehouseId:string
}


export interface InvoiceCategory{
    id:string
    category:string
}

export interface InvoiceInfo{
    id:string
    invoiceNumber: string
    date:string
    excl_taxes: number
    incl_taxes:number
    invoiceExist: boolean
    category: string
}

export interface InvoicePdf{
    invoicePdf: File | null
}

// export interface InvoiceFilter{
//     category:string|null
//     numero:string|null
//     date:Date|null
// }


// export interface InvoiceFilterInfo{

// }



