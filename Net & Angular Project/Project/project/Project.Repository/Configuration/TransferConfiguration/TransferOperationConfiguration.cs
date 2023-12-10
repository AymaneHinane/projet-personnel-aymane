
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration;


public class TransferOperationConfiguration : IEntityTypeConfiguration<TransferOperation>
{
    public void Configure(EntityTypeBuilder<TransferOperation> builder)
    {

       builder.HasKey(x=>x.Id);

       builder.Property(x=>x.TransferStatus).HasConversion(
         x=>x.ToString(),
         v=>(TransferStatus) Enum.Parse(typeof(TransferStatus),v)
       );
          

        builder.HasOne(x=>x.Transfer)
          .WithMany(x=>x.TransferOperations)
          .HasForeignKey(x=>x.TransferId)
          .OnDelete(DeleteBehavior.Cascade);


    }
}