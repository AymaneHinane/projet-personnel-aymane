using System;
using AspBookApp.Repository;
using Project.Contracts.Query;
using Project.Entities.Models;
using Project.Shared.RequestFeatures;

namespace Project.Repository.Inventory
{
	public class InvoiceQuery: RepositoryBase<Transfer>, IInvoiceQuery
    {
		public InvoiceQuery(RepositoryContext repositoryContext) : base(repositoryContext) { }


        public IQueryable<Invoice> InvoiceFilterQuery(InvoiceParameters invoiceParameters)
        {
            IQueryable<Invoice> filterQuery = repositoryContext.Invoices;

            if (invoiceParameters.category != null)
                filterQuery = filterQuery.Where(x => x.InvoiceCategory!.Category!.Equals(invoiceParameters.category));
            if (invoiceParameters.numero != null)
                filterQuery = filterQuery.Where(x => x.InvoiceNumber!.Equals(invoiceParameters.numero));
            if (invoiceParameters.date != null)
                filterQuery = filterQuery.Where(x => x.date.Equals(invoiceParameters.date));

            return filterQuery;
        }
    }
}

