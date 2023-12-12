
namespace Project.Contracts;


public interface  IInventoryRepositoryManager{

     IWarehouseRepository Warehouse{get;}
     IProductRepository Product{get;}
     Task SaveAsync();
}

