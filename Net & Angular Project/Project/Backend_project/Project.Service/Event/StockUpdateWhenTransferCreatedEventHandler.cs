using MediatR;
using Project.Contracts;
using Project.Entities.Event;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Shared.Dto;

namespace Project.Service.Event;


public class StockUpdateWhenTransferCreatedEventHandler:INotificationHandler<TransferCreatedDomainEvent>
{

    private readonly IInventoryServiceManager _inventoryServiceManager;
    private readonly IInventoryRepositoryManager _inventoryRepositoryManager;
    

    public StockUpdateWhenTransferCreatedEventHandler( IInventoryServiceManager inventoryServiceManger,IInventoryRepositoryManager inventoryRepositoryManager){
      _inventoryServiceManager = inventoryServiceManger;
      _inventoryRepositoryManager = inventoryRepositoryManager;
    }


    public async Task Handle(TransferCreatedDomainEvent transferCreatedDomainEvent, CancellationToken cancellationToken){
        
       var transfer = transferCreatedDomainEvent.transfer;

       var product =await _inventoryRepositoryManager.Product.GetProductByIdAsync(transfer!.ProductId,false);
     
       var stock = await _inventoryRepositoryManager.Warehouse.GetStockByProductId(transfer.SenderId,transfer.ProductId);

        

       ProductUpdateDto? NewStock = null;

       NewStock=new ProductUpdateDto(){
            TransferedStockExitTotal = stock!.TransferedStockExitTotal + transfer.TransferedStockQuantity
       };
  
       await _inventoryServiceManager.warehouseService.UpdateStock(transfer.SenderId,transfer.ProductId,product!.category,NewStock);

    }
}