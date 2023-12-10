using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration.InventoryConfiguration
{
	public class StockChangeHistoryConfiguration:IEntityTypeConfiguration<StockChangeHistory>
	{
		public StockChangeHistoryConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<StockChangeHistory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductCategory).HasConversion(
               v => v.ToString(),
               v => (Category)Enum.Parse(typeof(Category), v));

            builder.HasOne(x => x.warehouse)
                .WithMany(x => x.stockChangeHistories)
                .HasForeignKey(x => x.warehouseId);
        }

    }
}

