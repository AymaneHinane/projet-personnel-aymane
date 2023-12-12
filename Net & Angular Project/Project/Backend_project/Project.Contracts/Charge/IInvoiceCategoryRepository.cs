using System;
using Project.Entities.Models;


namespace Project.Contracts
{
	public interface IInvoiceCategoryRepository
    {

		Task<IEnumerable<InvoiceCategory>> getAllCategory(bool trackChange);
	}
}

