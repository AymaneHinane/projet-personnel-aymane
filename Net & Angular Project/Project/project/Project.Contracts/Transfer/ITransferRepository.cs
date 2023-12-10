

using Project.Entities.Models;
using Project.Shared.Dto;
using Project.Shared.Request;

namespace  Project.Contracts;


public interface  ITransferRepository{

   void TransferInsert(Transfer transfer);

   Task<Transfer?> GetTransferById(Guid transferId,bool trackChange=false);

   Task<ICollection<Recipients>> GetRecipientsByTransferId(Guid transferId,bool trackChange);

   Task<Boolean> VerifyIfRecipientExist(Guid transferId,Guid recipientId);

   Task<TransferOverviewDto?> TransferOverviewById(Guid transferId);

   IDictionary<string, Object> TransferGetUpdatedPropertyValue(Transfer transfer);

}