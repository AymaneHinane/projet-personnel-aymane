using System;
using Project.Entities.Models;
using Project.Shared.DataTransferObjects.Invoice;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;

namespace Project.Service.Contracts;

public interface IInvoiceService
{

    Task addNewInvoice(InvoiceCreateDto invoiceCreateDto);

    Task<(IEnumerable<InvoiceInfoDto> invoices, MetaData metaData)> getAllInvoicesByWarehouseId(Guid WarehouseId, InvoiceParameters parameters);

    Task<InvoicePdfDto?> getInvoicePdf(Guid invoiceId);
}

