using System;
using AspBookApp.Repository;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Entities.Models;

namespace Project.Repository
{
	public class InvoiceCategoryRepository: RepositoryBase<InvoiceCategory>,IInvoiceCategoryRepository
    {
		public InvoiceCategoryRepository(RepositoryContext context):base(context)
		{
		}

		public async Task<IEnumerable<InvoiceCategory>> getAllCategory(bool trackChange) => await
			 FindAll(trackChange).ToListAsync();
    }
}

