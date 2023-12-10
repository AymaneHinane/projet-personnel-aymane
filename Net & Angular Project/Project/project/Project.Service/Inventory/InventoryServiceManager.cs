using AutoMapper;
using MediatR;
using Project.Contracts;
using Project.Contracts.Logger;
using Project.Service.Contracts;

namespace Project.Service;

public class InventoryServiceManager:IInventoryServiceManager{

    private readonly Lazy<IWarehouseService> _warehouseService;
    private readonly Lazy<IProductService> _productService;
   
    public InventoryServiceManager(IInventoryRepositoryManager repository, ILoggerManager logger,IMapper mapper,IMediator mediator){
        _warehouseService = new Lazy<IWarehouseService>(()=>new WarehouseService(repository,logger,mapper,mediator));
        _productService = new Lazy<IProductService>(()=>new ProductService(repository,logger,mapper));
    }

    public IWarehouseService warehouseService => _warehouseService.Value;
    public IProductService productService => _productService.Value;
   


}