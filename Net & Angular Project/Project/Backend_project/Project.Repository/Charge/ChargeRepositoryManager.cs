using System;
using Project.Contracts;


namespace Project.Repository;

public class ChargeRepositoryManager: IChargeRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<IInvoiceRepository> _invoiceRepository;
	private readonly Lazy<IInvoiceCategoryRepository> _invoiceCategoryRepository;

	public ChargeRepositoryManager(RepositoryContext context,IQueryRepositoryManager queryRepositoryManager)
	{
      _repositoryContext = context;
	  _invoiceRepository = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(context,queryRepositoryManager));
	  _invoiceCategoryRepository = new Lazy<IInvoiceCategoryRepository>(() => new InvoiceCategoryRepository(context));
    }

    public IInvoiceRepository invoiceRepository => _invoiceRepository.Value;

    public IInvoiceCategoryRepository invoiceCategoryRepository => _invoiceCategoryRepository.Value;

    public async Task SaveChangeAsync()
    {
       await _repositoryContext.SaveChangesAsync();
    }
}

