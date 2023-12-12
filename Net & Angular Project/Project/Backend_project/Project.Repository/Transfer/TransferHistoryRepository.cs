

using AspBookApp.Repository;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Entities.Models;

namespace Project.Repository;


public class TransferHistoryRepository : RepositoryBase<TransferHistory>, ITransferHistoryRepository
{
    public TransferHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void AddTransferHistory(TransferHistory transferHistory) => this.Create(transferHistory);

    public async Task<TransferHistory?> GetTransferHistoryById(Guid transferHistoryId, bool trackChange) => await
        FindByCondition(x => x.TransferId.Equals(transferHistoryId), trackChange).FirstOrDefaultAsync();

}