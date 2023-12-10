import { WarehouseInfo } from "src/app/inventory/Models/Warehouse.model"
import { ProductInfo } from "src/app/inventory/Models/product.model"


export interface TransferInsert{
    SenderId:string | null
    Recipients:Recipient[] | null
    ProductId:string | null
    TransferedStockQuantity:number | null
    DestinationType:string | null
    [key: string]: string | number | Recipient[] | null
}

export interface TransferUpdate{
    transferedStockQuantity:number|null
    deliveredStockQuantity:number|null
    transferStatus:string|null
}

export interface Recipient{
    RecipientId:string
}


export interface TransferInfo{
    id: string
    numero: number
    sender:WarehouseInfo
    recipients:WarehouseInfo[]
    product:ProductInfo
    transferedStockQuantity: number
    transferStatus: string
    deliveryDate: Date
    shippedDate: Date | null
}


export interface PaginationInfo{
    currentPage: number
    totalPages: number
    pageSize: number
    totalCount: number
}


export interface RecipientInfo{
   id:string,
   name:string
}

export interface RecipientTransferInsert{
    RecipientId:string,
    DeliveredStock:number
}

export interface TransferOperationInsert{
    TruckNumber:string | null,
    ExitStockWeight:number | null,
    RecipientTransfers:RecipientTransferInsert[] // | null
    [key: string]: string | number | RecipientTransferInsert[] | null;
}


export interface RecipientTransferInfo{
    id:string 
    name:string | null
    deliveredStock:number | null
    transferStatus:string | null
}

export interface TransferOperationInfo{
    id: string 
    truckNumber: string | null
    deliveryDate:Date | null
    shippedDate: Date | null
    exitStockWeight: number | null
    entryStockWeight: number | null
    exitVoucherExist: boolean
    entryVoucherExist: boolean
    transferStatus: string | null
    recipientTransfer:RecipientTransferInfo[]
}


export interface TransferOperationUpdate{
    truckNumber:string | null
    deliveryDate:Date | null
    shippedDate:Date | null
    exitStockWeight:number | null
    entryStockWeight:number | null
    transferStatus:string | null
    [key: string]: string | number | Date | null
}

export interface RecipientTransferUpdate{
    id:string | null
    deliveredStock:number | null
    transferStatus:string | null
    [key: string]: string | number | null
}

export interface TransferOverview{
    recipientNbr:number
    transferOperationNbr:number
    deliveryNbr:number
    shippedNbr:number
    transferedStockQuantity:number
    transferedStockQuantityTotal:number
    transferedStockQuantityShipped:number
    percentageTransferStatus:number
}

export interface TransferFilter{
    numero:number | null
    sender:string | null
    recipient:string | null
    status:string | null
    recipientType:string | null
    region:string | null
    product:string | null
    qte:number | null
    deliveryDate:Date | null
    shippedDate:Date | null
    [key: string]: string | number | Date | null 
}

export interface TransferFilterApplied{
    filterProperty:string
    filterPropertyName:string
    value:string
}