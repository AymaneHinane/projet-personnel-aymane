

using Project.Entities.Models;

namespace Project.Contracts;

public interface IProductRepository{


   void AddNewProduct(Product product);
   Task<IEnumerable<Product>> GetAllProductAsync(Category category,bool trackChange);
   Task<Product?> GetProductByIdAsync(Guid id,bool trackChange);

   Task<IEnumerable<Product>?> GetAllProductStockByCategory(Category category,bool trackChange);
   Task<IEnumerable<Product>?> GetAllProductByWarehouseIdAndCategory(Guid Id,Category category,bool trackChange);

   Task<IEnumerable<Stock>> GetFinishedProductStock();
    
}