using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }

		public int OrderId { get; set; }
		public Order Order { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }

		public int Quantity { get; set; }
	}

    public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
			builder.HasKey(o => o.Id);

			builder.HasCheckConstraint("QuantityOrderCheck", @$" [{nameof(OrderDetail.Quantity)}] > 0 ");

			builder.HasKey(od => new { od.OrderId, od.ProductId });

			builder.HasOne(od => od.Order)
				.WithMany(o => o.OrderDetails)
				.HasForeignKey(od => od.OrderId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(od => od.Product)
				.WithMany(p => p.OrderDetails)
				.HasForeignKey(od => od.ProductId)
				.OnDelete(DeleteBehavior.NoAction);

        }
    }
}

