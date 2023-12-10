using System;
using AutoMapper;
using Project.Contracts;
using Project.Entities.Exceptions;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Shared.DataTransferObjects.Invoice;
using Project.Shared.Request;
using Project.Shared.RequestFeatures;

namespace Project.Service;

public class InvoiceService: IInvoiceService
{
	private readonly IChargeRepositoryManager _chargeRepository;
    private IMapper _mapper;

	public InvoiceService(IChargeRepositoryManager chargeRepository,IMapper mapper)
	{
		this._chargeRepository = chargeRepository;
        this._mapper = mapper;
	}

    public async Task addNewInvoice(InvoiceCreateDto invoiceCreateDto)
    {

        if (invoiceCreateDto.InvoicePdf == null || invoiceCreateDto.InvoicePdf.Length == 0)
            throw new BadRequestException("No file uploaded");

        using (var ms = new MemoryStream())
        {
            await invoiceCreateDto.InvoicePdf.CopyToAsync(ms);
            byte[] fileBytes = ms.ToArray();

            Invoice invoice = _mapper.Map<Invoice>(invoiceCreateDto);

            invoice.InvoicePdf = fileBytes;

            this._chargeRepository.invoiceRepository.AddInvoice(invoice);

            await _chargeRepository.SaveChangeAsync();
        }
    }

    public async Task<(IEnumerable<InvoiceInfoDto> invoices, MetaData metaData)> getAllInvoicesByWarehouseId(Guid WarehouseId, InvoiceParameters parameters)
    {
        var invoices = await _chargeRepository.invoiceRepository.getAllInvoicesByWarehouseId(WarehouseId, parameters,false);

        //var invoicesDto = _mapper.Map<IEnumerable<InvoiceInfoDto>>(invoices);

        return (invoices: invoices, metaData: invoices.MetaData);

    }

    public async Task<InvoicePdfDto?> getInvoicePdf(Guid invoiceId) => await
        _chargeRepository.invoiceRepository.getInvoicePdf(invoiceId);
}

