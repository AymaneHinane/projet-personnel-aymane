using System;
using MediatR;
using Project.Contracts;
using Project.Entities.Event;
using Project.Entities.Models;
using Project.Service.Contracts;


namespace Project.Service.Event
{
	public class TransferHistoryAddWhenTransferUpdatedEventHandler: INotificationHandler<TransferUpdatedDomainEvent>
    {
        ITransferRepositoryManager transferManager;
        IInventoryRepositoryManager inventoryManger;
        IInventoryServiceManager inventoryServiceManager;

        public TransferHistoryAddWhenTransferUpdatedEventHandler(ITransferRepositoryManager transferManager, IInventoryRepositoryManager inventoryRepository, IInventoryServiceManager inventoryServiceManager)
        {
            this.transferManager = transferManager;
            this.inventoryManger = inventoryRepository;
            this.inventoryServiceManager = inventoryServiceManager;
        }


        public async Task Handle(TransferUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {

            var transfer = notification.transfer;

            if (transfer!.DestinationType.Equals(WarehouseType.distributionCenter))
                return;

            IDictionary<string,Object> updatedProperty = transferManager.Transfer.TransferGetUpdatedPropertyValue(transfer);

            if (updatedProperty == null)
                return;

            if (updatedProperty.ContainsKey("TransferStatus"))
            {
                if(Object.Equals(updatedProperty["TransferStatus"],TransferStatus.delivery)
                                  && transfer.TransferStatus.Equals(TransferStatus.shipped)){

                    if(transfer.DeliveredStockQuantity > 0)
                       await AddTransferHistoryWhenShipped(transfer);
                }
            }



            Console.WriteLine("");
       
        }

        public async Task AddTransferHistoryWhenShipped(Transfer transfer)
        {
            var sender = await this.inventoryManger.Warehouse.GetWarehouseById(transfer!.SenderId, false);
            var recipients = await this.transferManager.Transfer.GetRecipientsByTransferId(transfer.Id, false);
            var recipient = recipients.First().Recipient;

            var product = await this.inventoryManger.Product.GetProductByIdAsync(transfer.ProductId, false);

            var recipientstock = await this.inventoryManger.Warehouse.GetStockByProductId(recipient!.Id, product!.Id);
            //var senderStock = await this.inventoryManger.Warehouse.GetStockByProductId(sender!.Id, product!.Id);

            var transferHistory = await this.transferManager.TransferHistory.GetTransferHistoryById(transfer.Id, true);
            transferHistory!.TranferNumero = transfer.Numero;

            var transferHistorySender = new TransferHistory()
            {
                EditedField = "transfere livrée",
                UpdateDate = DateTime.UtcNow,
                OldValue = recipientstock!.TransferedStockEntryTotal,
                NewValue = recipientstock.TransferedStockEntryTotal + transfer.DeliveredStockQuantity,
                SenderId = sender.Id,
                Recipient = recipient ,
                ProductId = product.Id,
                TransferId = transfer.Id,
                TranferNumero = transfer.Numero,
                SenderName = sender.Name,
                RecipientName = recipient.Name,
                ProductName = product.Name,
                ProductCategory = product.category
            };

            Console.WriteLine("");
            this.transferManager.TransferHistory.AddTransferHistory(transferHistorySender);
        }


    }
}

