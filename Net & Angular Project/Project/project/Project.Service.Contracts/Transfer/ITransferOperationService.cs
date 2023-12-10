
using Project.Entities.Models;
using Project.Shared;
using Project.Shared.Dto;

namespace Project.Service.Contracts;


public interface ITransferOperationService{
    Task UpdateTransferOperation(Guid Id,TransferOperationUpdateDto transferOperationUpdateDto);
    Task UpdateRecipientTransfer(Guid tranferOperationId,ICollection<RecipientTransferUpdateDto> recipientsTransferUpdateDtos);
    Task AddVoucher(Guid transferOperationId,voucherType type,byte[] file);

    Task<byte[]> GetVoucher(Guid transferOperationId, voucherType type);
}