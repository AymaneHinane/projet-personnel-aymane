

using AspBookApp.Repository;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Entities.Models;
using Project.Shared.Dto;
using Project.Shared.Request;

namespace Project.Repository;


public class TransferRepository : RepositoryBase<Transfer>, ITransferRepository
{
    public TransferRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

     public async Task<Transfer?> GetTransferById(Guid transferId,bool trackChange) => await 
      this.repositoryContext.Transfers!.FindAsync(transferId);
    //  FindByCondition(x=>x.Id.Equals(transferId),trackChange).FirstOrDefaultAsync();


    public void TransferInsert(Transfer transfer) => Create(transfer);


    public async Task<ICollection<Recipients>> GetRecipientsByTransferId(Guid transferId, bool trackChange)
    {
        var data = repositoryContext.ChangeTracker.Entries<Recipients>()
            .Select(entry => entry.Entity)
            .ToList();

        if (data.Count() > 0 )
            return data;
        else
          return await this.repositoryContext.Recipients!
              .Where(x => x.TransferId.Equals(transferId))
              .Include(x => x.Recipient)
              .ToListAsync();
     }


    public async Task<bool> VerifyIfRecipientExist(Guid transferId, Guid recipientId) => await
      this.repositoryContext.Recipients!.Where(x=>x.TransferId.Equals(transferId) && x.RecipientId.Equals(recipientId)).AnyAsync();


    public async Task<TransferOverviewDto?> TransferOverviewById(Guid transferId) => await
      this.repositoryContext.Transfers!
      .Where(x=>x.Id.Equals(transferId))
      .Include(x=>x.Recipients)
      .Include(x=>x.TransferOperations)!
      .ThenInclude(x=>x.RecipientTransfers)
      .Select(x=>new TransferOverviewDto(){
          RecipientNbr= x.Recipients!.Count(), //nbr de destination
          TransferOperationNbr = x.TransferOperations!.Count(), // nbr de camion sortie
          DeliveryNbr = x.TransferOperations!.Count(x=>x.TransferStatus.Equals(TransferStatus.delivery)), //en cour de livraison
          ShippedNbr = x.TransferOperations!.Count(x=>x.TransferStatus.Equals(TransferStatus.shipped)), // livraison terminer
          TransferedStockQuantity = x.TransferedStockQuantity, // stock a transferer

          TransferedStockQuantityTotal = x.TransferOperations!
                .Where(op => op.TransferStatus.Equals(TransferStatus.delivery))
                .SelectMany(op => op.RecipientTransfers!).Sum(r => r.DeliveredStock), //en cour

          TransferedStockQuantityShipped = x.TransferOperations!
                .Where(op => op.TransferStatus.Equals(TransferStatus.shipped))  //livrer
                .SelectMany(op => op.RecipientTransfers!).Sum(r => r.DeliveredStock) ,

          PercentageTransferStatus = x.TransferOperations!.Count() > 0 ? (
                (decimal)(x.TransferOperations!.Count(x=>x.TransferStatus.Equals(TransferStatus.shipped)) ) 
                 / x.TransferOperations!.Count()
          )*100:1


       }).FirstOrDefaultAsync();

    public IDictionary<string, Object> TransferGetUpdatedPropertyValue(Transfer transfer)
    {
        var entry = this.repositoryContext.ChangeTracker.Entries<Transfer>()
            .FirstOrDefault(entry => entry.State == EntityState.Modified && entry.Entity.Id == transfer.Id);

        if(entry != null)
        {
            var updatedProperty = new Dictionary<string, Object>();

            foreach(var property in entry.OriginalValues.Properties)
            {
                var originalValue = entry.OriginalValues[property];
                var currentValue = entry.CurrentValues[property];

                if (!object.Equals(originalValue, currentValue))
                {
                    updatedProperty.Add(property.Name,originalValue!);
                }
            }

            return updatedProperty;
        }

        return null;
    }

    // public Transfer GetTrackedTransfer(Guid transferId) => 
    //     this.repositoryContext.ChangeTracker.Entries<Transfer>()
    //     .FirstOrDefault(entry => entry.Entity.Id == transferId)!.Entity;
}