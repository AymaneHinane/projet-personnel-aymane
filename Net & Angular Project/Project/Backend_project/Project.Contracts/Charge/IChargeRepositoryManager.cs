using System;
namespace Project.Contracts
{
	public interface IChargeRepositoryManager
	{
        IInvoiceRepository invoiceRepository { get; }
        IInvoiceCategoryRepository invoiceCategoryRepository { get; }

        Task SaveChangeAsync();
    }
}

