namespace Project.Contracts;


public interface ITransferRepositoryManager{

    ITransferRepository Transfer {get;}
    ITransferOperationRepository TransferOperation {get;}
    ITransferHistoryRepository TransferHistory{get;}

    Task SaveAsync();
    
}