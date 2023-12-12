
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration;


public class TransferHistoryConfiguration : IEntityTypeConfiguration<TransferHistory>
{
    public void Configure(EntityTypeBuilder<TransferHistory> builder)
    {
        builder.HasKey(x=>x.Id);


        builder.Property(x=>x.ProductCategory)
        .HasConversion(
          v=>v.ToString(),
          v=>(Category) Enum.Parse(typeof(Category),v)
        );

        builder.HasOne(x=>x.Sender)
          .WithMany(x=>x.TransferHistory)
          .HasForeignKey(x=>x.SenderId)
          .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x=>x.Recipient)
          .WithMany(x=>x.DeliveryHistory)
          .HasForeignKey(x=>x.RecipientId)
          .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x=>x.Product)
          .WithMany(x=>x.TransferHistory)
          .HasForeignKey(x=>x.ProductId)
          .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x=>x.Transfer)
           .WithMany(x=>x.TransferHistory)
           .HasForeignKey(x=>x.TransferId)
           .OnDelete(DeleteBehavior.Restrict);
    }


}