using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models
{
	public class Store
	{
		public int Id { get; set; }

		public List<Employee> Employees { get; set; }

        public List<Order> Orders { get; set; }


	}

    public class StoreEntityTypeConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Employees)
                .WithOne(e => e.Store)
                .HasForeignKey(e => e.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Orders)
               .WithOne(o => o.Store)
               .HasForeignKey(o => o.StorId)
               .OnDelete(DeleteBehavior.NoAction);


        }
    }


}

