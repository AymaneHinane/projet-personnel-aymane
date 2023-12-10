namespace Project.Service.Contracts;



public interface IInventoryServiceManager{
   IWarehouseService warehouseService {get;}
   IProductService productService{get;}
}