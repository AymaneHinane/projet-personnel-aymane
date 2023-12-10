using System;
using Project.Entities.Models;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;

namespace Project.Contracts.Query
{
	public interface IInvoiceQuery
    {
        IQueryable<Invoice> InvoiceFilterQuery(InvoiceParameters invoiceParameters);
    }
}

