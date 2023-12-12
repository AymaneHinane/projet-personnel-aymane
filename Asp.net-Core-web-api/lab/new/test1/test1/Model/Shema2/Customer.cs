using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test1.Model.Shema2
{
	public class Customer
	{
        public int CustomerId;
        public string FirstName;
        public string LastName;

        public ICollection<Order> Orders;

	}

    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(30).IsRequired();

            builder.HasIndex(c => c.FirstName).IsUnique();

            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);
        }
    }


}

