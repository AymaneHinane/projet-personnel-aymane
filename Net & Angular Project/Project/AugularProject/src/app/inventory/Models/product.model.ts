
export interface warehouseInfo{
    id:string
    name:string
}


export interface ProductInfo{
    id:string
    name:string
    category:string
}

export interface ProductStockInfo{
    name:string
    stocks:ProductStock[]
}


export interface ProductStock{

    name:string,

    stockProduced:number
    //cdaDeliverStock:number
    transferedStockExitTotal:number

    orderStock:number ,
    deliverStock:number,
    consumeStock:number,
    lastYearRemainingStock:number,
    dapStock:number,

    remainingStock:number,

    warehouse:warehouseInfo
}


export interface AddProduct{
    name:string,
    category:string
}