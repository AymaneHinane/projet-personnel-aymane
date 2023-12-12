using System;
using Project.Entities.Models;
using Project.Shared.DataTransferObjects.Invoice;

namespace Project.Service.Contracts;

public interface IInvoiceCategoryService
{
    Task<IEnumerable<InvoiceCategoryInfoDto>> getAllCategory();
}

