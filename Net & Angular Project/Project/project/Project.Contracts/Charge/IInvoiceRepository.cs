using System;
using Project.Entities.Models;
using Project.Shared.DataTransferObjects.Invoice;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;

namespace Project.Contracts
{
	public interface IInvoiceRepository
    {
		void AddInvoice(Invoice invoice);

		Task<PagedList<InvoiceInfoDto>> getAllInvoicesByWarehouseId(Guid WarehouseId, InvoiceParameters parameters,bool trackChange);

		Task<InvoicePdfDto?> getInvoicePdf(Guid invoiceId);
	}
}

