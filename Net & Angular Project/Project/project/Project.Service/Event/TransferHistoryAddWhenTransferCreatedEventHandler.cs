
using MediatR;
using Project.Contracts;
using Project.Entities.Event;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Shared.Dto;

namespace Project.Service.Event;


public class TransferHistoryAddWhenTransferCreatedEventHandler : INotificationHandler<TransferCreatedDomainEvent>
{

    ITransferRepositoryManager transferManager;
    IInventoryRepositoryManager inventoryManger;
    IInventoryServiceManager inventoryServiceManager;
   

    public TransferHistoryAddWhenTransferCreatedEventHandler(ITransferRepositoryManager transferManager,IInventoryRepositoryManager inventoryRepository,    IInventoryServiceManager inventoryServiceManager){
        this.transferManager = transferManager;
        this.inventoryManger = inventoryRepository;
        this.inventoryServiceManager = inventoryServiceManager;
    }
    
    public async Task Handle(TransferCreatedDomainEvent notification, CancellationToken cancellationToken)
    {

        var transfer = notification.transfer;

        var sender = await this.inventoryManger.Warehouse.GetWarehouseById(transfer!.SenderId,false);

        Warehouse? recipient = null;

        if(transfer.DestinationType.Equals(WarehouseType.site))
            recipient = await this.inventoryManger.Warehouse.GetWarehouseById(transfer.Recipients!.First().RecipientId,false);

        var product = await this.inventoryManger.Product.GetProductByIdAsync(transfer.ProductId,false);

        var SenderStock = await this.inventoryManger.Warehouse.GetStockByProductId(sender!.Id,product!.Id);


        var transferHistorySender = new TransferHistory(){
                EditedField = transfer.DestinationType.Equals(WarehouseType.site) ?"consommée":"livrée CDA",
                UpdateDate = DateTime.UtcNow,
                OldValue = SenderStock!.TransferedStockExitTotal,
                NewValue = SenderStock.TransferedStockExitTotal + transfer.TransferedStockQuantity ,
                SenderId = sender.Id,
                Recipient = recipient??null,
                ProductId = product.Id,
                TransferId = transfer.Id,
                TranferNumero = transfer.Numero,
                SenderName = sender.Name,
                RecipientName = recipient == null ? "cda":recipient.Name,//String.Join('/',recipientInfo.Select(x=>x.Name)),
                ProductName = product.Name,
                ProductCategory = product.category
        };

        this.transferManager.TransferHistory.AddTransferHistory(transferHistorySender); 
 
    }

}