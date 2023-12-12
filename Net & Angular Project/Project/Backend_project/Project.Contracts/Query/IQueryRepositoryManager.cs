

using Project.Contracts.Query;

namespace Project.Contracts;

public interface IQueryRepositoryManager{
    
    ITransferQuery transfer{get;}
    IInvoiceQuery invoice { get; }
}