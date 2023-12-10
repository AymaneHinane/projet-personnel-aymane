



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;


namespace Project.Repository.Configuration;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {

        builder.HasKey(x=>x.Id);

        builder.HasIndex(x=>new{x.productId,x.warehouseId}).IsUnique();

        builder.HasOne(x=>x.warehouse).WithMany(x=>x.Stocks).HasForeignKey(x=>x.warehouseId);

        builder.HasOne(x=>x.product).WithMany(x=>x.Stocks).HasForeignKey(x=>x.productId);
        
    }
}