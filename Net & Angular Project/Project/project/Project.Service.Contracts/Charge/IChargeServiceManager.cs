using System;
namespace Project.Service.Contracts;

	public interface IChargeServiceManager
	{
    IInvoiceService InvoiceService { get; }
    IInvoiceCategoryService InvoiceCategoryService { get; }
}

