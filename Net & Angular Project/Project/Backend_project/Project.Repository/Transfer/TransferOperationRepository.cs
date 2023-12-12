

using AspBookApp.Repository;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Entities.Models;
using Project.Shared;

namespace Project.Repository;

public class TransferOperationRepository : RepositoryBase<TransferOperation>, ITransferOperationRepository
{
    public TransferOperationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<ICollection<TransferOperation>> GetAllTransferOperationByTransferId(Guid transferId,bool trackChange) => await
       FindByCondition(x=>x.TransferId.Equals(transferId),trackChange)
       .OrderByDescending(x=>x.DeliveryDate)
       .Include(x=>x.RecipientTransfers)!
       .ThenInclude(x=>x.Recipient)
       .ThenInclude(x=>x!.Recipient)
       .ToListAsync();

    public async Task<TransferOperation?> GetTransferOperationById(Guid Id, bool trackChange) => await
       FindByCondition(x=>x.Id.Equals(Id),trackChange)
       .FirstOrDefaultAsync();

    public async Task<ICollection<RecipientTransfer>> GetRecipientTransfersByTransferOperationId(Guid transferOperationId) => await
      this.repositoryContext.RecipientTransfers!
      .AsTracking()
      .Where(x=>x.TransferOperationId.Equals(transferOperationId))
      .ToListAsync();

    public async Task<ICollection<Warehouse?>> GetRecipientInfoByRecipientTransferId(ICollection<RecipientTransfer> recipientTransfers)
    {
      //  this.repositoryContext.Recipients!.Where(x=>recipientTransfers.Any(y=>y.RecipientId.Equals(x.Id)))
      //  .Include(x=>x.Recipient)
      //  .Select(x=>x.Recipient).ToListAsync();

        var recipientIds = recipientTransfers.Select(rt => rt.RecipientId).ToList();

        return await this.repositoryContext.Recipients!
          .AsNoTracking()
          .Where(r => recipientIds.Contains(r.Id))
          .Select(r => r.Recipient)
          .ToListAsync();
    }


    public async Task<byte[]?> GetVoucher(Guid transferOperationId, voucherType type)
    {
        IQueryable<TransferOperation> query1 = FindByCondition(x=>x.Id.Equals(transferOperationId),false);
        IQueryable<byte[]> query2 = null!; 

        if(type == voucherType.exit)
          query2 = query1.Select(x=>x.ExitVoucher)!;
        else if(type == voucherType.entry)
          query2 = query1.Select(x=>x.EntryVoucher)!;

        
        return await query2!.FirstOrDefaultAsync();
    }
}