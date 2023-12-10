using System;
using AspBookApp.Repository;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Entities.Models;
using Project.Shared.DataTransferObjects.Invoice;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.Repository
{
	public class InvoiceRepository:RepositoryBase<Invoice>, IInvoiceRepository
    {
		private readonly IQueryRepositoryManager _queryRepositoryManager;

        public InvoiceRepository(RepositoryContext context, IQueryRepositoryManager queryRepositoryManager) :base(context)
		{
			_queryRepositoryManager = queryRepositoryManager;
		}

		public void AddInvoice(Invoice invoice) => Create(invoice);

		public async Task<PagedList<InvoiceInfoDto>> getAllInvoicesByWarehouseId(Guid WarehouseId, InvoiceParameters parameters, bool trackChange)
		{
			var inventoryFilter = _queryRepositoryManager.invoice.InvoiceFilterQuery(parameters);


			var invoices = await FindByConditionWithInclude(x => x.WarehouseId.Equals(WarehouseId), trackChange, x => x.InvoiceCategory!)
			               .Where(x=>inventoryFilter.Contains(x))
			               .Select( x => new InvoiceInfoDto()
		                   {
			                	Id = x.Id,
			                	InvoiceNumber = x.InvoiceNumber,
			                 	date = x.date,
			                  	Excl_taxes = x.Excl_taxes,
			                  	Incl_taxes = x.Incl_taxes,
			                 	Category = x.InvoiceCategory!.Category,
								InvoiceExist = (from invoice in repositoryContext.Invoices
												where x.Id.Equals(invoice.Id) && x.InvoicePdf != null select x).Any()												
			               })
                           .OrderByDescending(x => x.date)
                           .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                           .Take(parameters.PageSize)
                           .ToListAsync();

			var count = await FindByConditionWithInclude(x => x.WarehouseId.Equals(WarehouseId), trackChange, x => x.InvoiceCategory!)
						   .Where(x => inventoryFilter.Contains(x)).CountAsync();

			return new PagedList<InvoiceInfoDto>(invoices, count, parameters.PageNumber, parameters.PageSize);
        }

		public async Task<InvoicePdfDto?> getInvoicePdf(Guid invoiceId) => await
			FindByCondition(x => x.Id.Equals(invoiceId),false).Select(x => new InvoicePdfDto
            {
                InvoicePdf = x.InvoicePdf
            }).FirstOrDefaultAsync();
    }
}

