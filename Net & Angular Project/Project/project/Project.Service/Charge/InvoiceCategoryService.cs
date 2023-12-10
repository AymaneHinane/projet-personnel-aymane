using System;
using AutoMapper;
using Project.Contracts;
using Project.Service.Contracts;
using Project.Shared.DataTransferObjects.Invoice;

namespace Project.Service;

public class InvoiceCategoryService: IInvoiceCategoryService
{
    private readonly IChargeRepositoryManager _chargeRepository;
    private readonly IMapper _mapper;

    public InvoiceCategoryService(IChargeRepositoryManager chargeRepository, IMapper mapper)
	{
        this._chargeRepository = chargeRepository;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<InvoiceCategoryInfoDto>> getAllCategory()
    {
        var category = await this._chargeRepository.invoiceCategoryRepository.getAllCategory(false);

        return _mapper.Map<IEnumerable<InvoiceCategoryInfoDto>>(category);
    }
}

