

using Project.Entities.Models;
using Project.Shared;

namespace  Project.Contracts;


public interface ITransferOperationRepository{
   
    Task<ICollection<TransferOperation>> GetAllTransferOperationByTransferId(Guid transferId,bool trackChange);
   
    Task<TransferOperation?> GetTransferOperationById(Guid Id,bool trackChange);

    Task<ICollection<RecipientTransfer>> GetRecipientTransfersByTransferOperationId(Guid transferOperationId);

    Task<byte[]?> GetVoucher(Guid transferOperationId, voucherType type);

    Task<ICollection<Warehouse?>> GetRecipientInfoByRecipientTransferId(ICollection<RecipientTransfer> recipientTransfers);
  
}