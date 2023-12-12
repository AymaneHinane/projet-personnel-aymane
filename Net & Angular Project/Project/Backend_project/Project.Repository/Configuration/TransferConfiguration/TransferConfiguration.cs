
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration;



public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {

       builder.HasKey(x=>x.Id);

       builder.Property(x=>x.TransferStatus).HasConversion(
        x=>x.ToString(),
        v=>(TransferStatus) Enum.Parse(typeof(TransferStatus),v));

      builder.Property(x=>x.DestinationType).HasConversion(
        x=>x.ToString(),
        v=>(WarehouseType) Enum.Parse(typeof(WarehouseType),v));

       builder.Property(x=>x.Numero).ValueGeneratedOnAdd();

       builder.HasOne(x=>x.Sender)
         .WithMany(x=>x.transfers)
         .HasForeignKey(x=>x.SenderId)
          .OnDelete(DeleteBehavior.Cascade);
    }
}