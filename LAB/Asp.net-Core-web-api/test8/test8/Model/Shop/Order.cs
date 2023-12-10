using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model.Shop
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime? DeleveryDate { get; set; }
		public DateTime? OrderDate { get; set; }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }


		public ShippingAdresse shippingAdresse { get; set; }

		public List<OrderDetails>? OrderDetails { get; set; }
	}


    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
			builder.HasKey(o => o.Id);
			//builder.Property(o => o.OrderDate).HasComputedColumnSql("getdate()");
            //builder.Property(o => o.DeleveryDate)/.IsRequired(false);
			
			builder.HasOne(o => o.shippingAdresse)
				.WithOne(sa => sa.Order)
				.HasForeignKey<ShippingAdresse>(sa => sa.OrderId);

			builder.HasCheckConstraint("CK_OrderDate", @$"[{nameof(Order.DeleveryDate)}] > [{nameof(Order.OrderDate)}]");

            //DeleveryDate = (DateTime?)null, OrderDate = DateTime.UtcNow
            builder.HasData(
					new { Id = 1, CustomerId = 1, OrderDate =DateTime.Now},
					new { Id = 2, CustomerId = 1, OrderDate = DateTime.Now },
					new { Id = 3,  CustomerId = 2, OrderDate = DateTime.Now }
				);
        }
    }
}

