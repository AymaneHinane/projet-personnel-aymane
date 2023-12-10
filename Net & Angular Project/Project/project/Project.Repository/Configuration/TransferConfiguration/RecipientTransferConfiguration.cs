
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration;



public class RecipientTransferConfiguration : IEntityTypeConfiguration<RecipientTransfer>
{
    public void Configure(EntityTypeBuilder<RecipientTransfer> builder)
    {
        //builder.HasKey(x=>new{x.RecipientId,x.TransferOperationId});

        builder.HasKey(x=>x.Id);
        builder.HasIndex(x => new { x.TransferOperationId, x.RecipientId }).IsUnique();

        builder.Property(x=>x.TransferStatus).HasConversion(
        x=>x.ToString(),
        v=>(TransferStatus) Enum.Parse(typeof(TransferStatus),v));

        builder
            .HasOne(rt => rt.transferOperation)
            .WithMany(to => to.RecipientTransfers)
            .HasForeignKey(rt => rt.TransferOperationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(rt => rt.Recipient)
            .WithMany(r => r.RecipientTransfers)
            .HasForeignKey(rt => rt.RecipientId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}