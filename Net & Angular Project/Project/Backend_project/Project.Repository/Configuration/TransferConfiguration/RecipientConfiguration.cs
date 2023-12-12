

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;

namespace Project.Repository.Configuration;

public class RecipientConfiguration : IEntityTypeConfiguration<Recipients>
{
    public void Configure(EntityTypeBuilder<Recipients> builder)
    {
       builder.HasKey(x=>x.Id);
       //builder.HasKey(x=>new{x.RecipientId,x.TransferId});

       builder.HasIndex(x=>new{x.RecipientId,x.TransferId}).IsUnique();

       builder.HasOne(x=>x.Transfer)
          .WithMany(x=>x.Recipients) 
          .HasForeignKey(x=>x.TransferId)
          .OnDelete(DeleteBehavior.Cascade);

       builder.HasOne(x=>x.Recipient)
          .WithMany(x=>x.deliveries)
          .HasForeignKey(x=>x.RecipientId)
          .OnDelete(DeleteBehavior.Restrict);
    }
}