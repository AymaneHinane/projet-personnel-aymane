
using Project.Contracts;
using Project.Entities.Models;

namespace Project.Repository;

public class InventoryRepositoryManager:IInventoryRepositoryManager {

    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IWarehouseRepository> _warehouseRepository;
    private readonly Lazy<IProductRepository> _productRepository;

    public InventoryRepositoryManager(RepositoryContext repositoryContext,IQueryRepositoryManager queryRepositoryManager){
         _repositoryContext = repositoryContext;
         _warehouseRepository = new Lazy<IWarehouseRepository>(()=>new WarehouseRepository(repositoryContext,queryRepositoryManager));
         _productRepository = new Lazy<IProductRepository>(()=>new ProductRepository(repositoryContext));
    }

    public IWarehouseRepository Warehouse => _warehouseRepository.Value;
    public IProductRepository Product => _productRepository.Value;
    
    public async Task SaveAsync() => await _repositoryContext.SaveChangesStockAsync();

} 