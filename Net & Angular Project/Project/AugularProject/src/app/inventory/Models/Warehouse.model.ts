


export interface WarehouseInfo{
    id:string
    name:string,
    warehouseType:string,
    //warehouseRegion:string
}

export interface WarehouseRegion{
    warehouseRegion:string,
    warehouseInfo:WarehouseInfo[]
}
