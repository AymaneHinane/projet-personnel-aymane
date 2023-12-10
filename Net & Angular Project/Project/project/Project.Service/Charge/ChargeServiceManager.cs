using System;
using AutoMapper;
using Project.Contracts;
using Project.Service.Contracts;

namespace Project.Service
{
	public class ChargeServiceManager: IChargeServiceManager
    {
		private readonly Lazy<IInvoiceService> _invoiceService;
		private readonly Lazy<IInvoiceCategoryService> _invoiceCategoryService;

		public ChargeServiceManager(IChargeRepositoryManager chargeRepository, IMapper mapper)
		{
			_invoiceService = new Lazy<IInvoiceService>(() => new InvoiceService(chargeRepository,mapper));
            _invoiceCategoryService = new Lazy<IInvoiceCategoryService>(() => new InvoiceCategoryService(chargeRepository,mapper));
        }

        public IInvoiceService InvoiceService => _invoiceService.Value;

        public IInvoiceCategoryService InvoiceCategoryService => _invoiceCategoryService.Value;
    }
}

