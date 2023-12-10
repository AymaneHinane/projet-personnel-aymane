
using Project.Entities.Models;

namespace Project.Contracts;

public interface ITransferHistoryRepository{

   void AddTransferHistory(TransferHistory transferHistory);
   Task<TransferHistory?> GetTransferHistoryById(Guid transferHistoryId,bool trackChange);
}