using Project.Contracts;
using Project.Contracts.Query;
using Project.Repository.Inventory;

namespace Project.Repository;


public class QueryRepositoryManager:IQueryRepositoryManager{

    private readonly Lazy<ITransferQuery> _transferQuery;
    private readonly Lazy<IInvoiceQuery> _invoiceQuery;


    public QueryRepositoryManager(RepositoryContext repositoryContext){
        _transferQuery = new Lazy<ITransferQuery>(()=>new TransferQuery(repositoryContext));
        _invoiceQuery = new Lazy<IInvoiceQuery>(() => new InvoiceQuery(repositoryContext));
    }

    public ITransferQuery transfer => _transferQuery.Value;

    public IInvoiceQuery invoice => _invoiceQuery.Value;
}


