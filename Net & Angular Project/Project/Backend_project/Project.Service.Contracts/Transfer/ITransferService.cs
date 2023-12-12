

using Project.Entities.Models;
using Project.Shared.Dto;
using Project.Shared.Request;



namespace Project.Service.Contracts;


public interface ITransferService{
   
   Task TransferInsert(TransferInsertDto transferDto);

   Task AddNewDelivery(Guid transferId,TransferOperationInsertDto transferOperationInsertDto);

   Task<IEnumerable<DestinationInfoDto?>> GetRecipientsByTransferId(Guid transferId);

   Task<ICollection<TransferOperationInfoDto>> GetTransferOperationByTransferId(Guid transferId);

   Task<TransferOverviewDto?> TransferOverviewById(Guid transferId);

   Task UpdateTransfer(Guid transferId, TransferUpdateDto transferUpdateDto);
   
   
   
}