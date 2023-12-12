using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration
{
	public class InvoiceConfiguration:IEntityTypeConfiguration<Invoice>
	{
		public InvoiceConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.InvoiceCategory).WithMany(x => x.Invoices).HasForeignKey(x => x.InvoiceCategoryId);

            builder.HasOne(x => x.Warehouse).WithMany(x => x.Invoices).HasForeignKey(x => x.WarehouseId);
        }
    }
}

