
export interface WarehouseRawMaterialStock{
    name:string,
    category:string
    stocks:RawMaterialStock[]
}


export interface WarehouseFinishedProductStock{
    name:string,
    category:string
    stocks:FinishedProductStock[]
}



export interface RawMaterialStock {

    warehouseId:string,
    productId:string,
    productName:string,
    orderStock:number ,
    deliverStock:number,
    consumeStock:number,
    remainingStock:number,
    lastYearRemainingStock:number,
    transferedStockEntryTotal:number,
    transferedStockExitTotal:number,
    dapStock:number,
    [key: string]: string | number;
}


export interface FinishedProductStock{
    warehouseId:string,
    productId:string,
    productName:string,
    stockProduced:number,
    transferedStockExitTotal:number,
    remainingStock:number,
    [key: string]: string | number;
}



export interface UpdateRawMaterialStock{
    orderStock:number | null ,
    deliverStock:number | null ,
    consumeStock:number | null ,
    transferedStockEntryTotal:number | null,
    transferedStockExitTotal:number | null,
}

export interface UpdateFinishedProductStock{
    stockProduced:number | null ,
    transferedStockExitTotal:number | null,
}