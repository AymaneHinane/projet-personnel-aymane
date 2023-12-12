using System;
using MediatR;
using Project.Contracts;
using Project.Entities.Event;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Shared.Dto;

namespace Project.Service.Event
{
	public class StockUpdateWhenTransferUpdatedEventHandler: INotificationHandler<TransferUpdatedDomainEvent>
    {

        private readonly IInventoryServiceManager _inventoryServiceManager;
        private readonly IInventoryRepositoryManager _inventoryRepositoryManager;
        private readonly ITransferRepositoryManager _transferManager;


        public StockUpdateWhenTransferUpdatedEventHandler(IInventoryServiceManager inventoryServiceManger, IInventoryRepositoryManager inventoryRepositoryManager, ITransferRepositoryManager transferManager)
		{
            _inventoryServiceManager = inventoryServiceManger;
            _inventoryRepositoryManager = inventoryRepositoryManager;
            _transferManager = transferManager;
        }

        public async Task Handle(TransferUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var transfer = notification.transfer;

            IDictionary<string, Object> updatedProperty = _transferManager.Transfer.TransferGetUpdatedPropertyValue(transfer);

            if (updatedProperty == null)
                return;

            if (updatedProperty.ContainsKey("TransferStatus"))
            {
                if (Object.Equals(updatedProperty["TransferStatus"], TransferStatus.delivery)
                                  && transfer.TransferStatus.Equals(TransferStatus.shipped)){

                    if (transfer.DeliveredStockQuantity > 0)
                        await UpdateStockWhenShipped(transfer);
                }
            }

        }


        public async Task UpdateStockWhenShipped(Transfer transfer)
        {
            var product = await _inventoryRepositoryManager.Product.GetProductByIdAsync(transfer!.ProductId, false);

            var recipients = await this._transferManager.Transfer.GetRecipientsByTransferId(transfer.Id, false);
            var recipient = recipients.First().Recipient;

            var recipientStock = await _inventoryRepositoryManager.Warehouse.GetStockByProductId(recipient!.Id, transfer.ProductId);

            ProductUpdateDto? NewStock = null;

            NewStock = new ProductUpdateDto()
            {
                TransferedStockEntryTotal = recipientStock!.TransferedStockEntryTotal + transfer.DeliveredStockQuantity
            };

            await _inventoryServiceManager.warehouseService.UpdateStock(recipient.Id, transfer.ProductId, product!.category, NewStock);
        }

    }
}

