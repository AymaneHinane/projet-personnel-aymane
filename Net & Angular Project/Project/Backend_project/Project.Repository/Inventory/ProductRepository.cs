


using AspBookApp.Repository;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Entities.Models;

namespace Project.Repository;
public class ProductRepository: RepositoryBase<Product>,IProductRepository{

     public ProductRepository(RepositoryContext repositoryContext): base(repositoryContext)
    {
    }

    public  void AddNewProduct(Product product) => Create(product);

    public async Task<IEnumerable<Product>> GetAllProductAsync(Category category,bool trackChange) => await
         FindByCondition(x=>x.category.Equals(category),trackChange).ToListAsync();

    public async Task<Product?> GetProductByIdAsync(Guid id, bool trackChange) => await
    // FindByCondition(x=>x.Id.Equals(id),trackChange).FirstOrDefaultAsync();
       this.repositoryContext.Products!.FindAsync(id);

    public async Task<IEnumerable<Product>?> GetAllProductStockByCategory(Category category, bool trackChange) => await
      this.repositoryContext.Products!
      .Where(x=>x.category.Equals(category))
      .Include(x=>x.Stocks)!
      .ThenInclude(x=>x.warehouse)
      .ToListAsync();

    public async Task<IEnumerable<Product>?> GetAllProductByWarehouseIdAndCategory(Guid Id, Category category, bool trackChange) => await
      this.repositoryContext.Products!
      .Where(x=>x.category.Equals(category) && x.Stocks!.Any(X=>X.warehouseId.Equals(Id))).ToListAsync();

    public async Task<IEnumerable<Stock>> GetFinishedProductStock() => await
        this.repositoryContext.Stocks!.Where(x => x.product!.category.Equals(Category.finishedProduct))
        .Include(x => x.product)
        .Include(x => x.warehouse)
        .ToListAsync();
}