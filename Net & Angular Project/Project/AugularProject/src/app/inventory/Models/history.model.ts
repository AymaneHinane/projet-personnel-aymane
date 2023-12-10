

export interface StockChangeHistory {
    id: string
    // property: string
    oldValue: number
    newValue: number
    PropertyNameEng: string
    propertyNameFr: string
    productName:string
    productCategory: string
    warehouseId: string
    // warehouse: null,
    updatedDate: Date
}

export interface TransferHistory {
    id: string
    editedField: string
    updateDate: Date
    oldValue: number
    newValue: number
    transferId: string
    tranferNumero:string
    // transfer: null,
    senderId: string
    // sender: null,
    senderName: string
    recipientId:string
    // recipient: null,
    recipientName: string
    productId: string
    // product: null,
    productName: string
    productCategory: string
}