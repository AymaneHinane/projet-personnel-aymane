using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model.Shop
{
	public class OrderDetails
	{
		public int OrderId { get; set; }
		public Order Order { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }

		public int OrderQuantity { get; set; }
	}



    class OrderDetailsEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
			builder.HasKey(od=> new {od.OrderId,od.ProductId });

			//builder.Property(od => od.Order).IsRequired();
            //builder.Property(od => od.Product).IsRequired();

            builder.HasOne(od => od.Order)
				.WithMany(o => o.OrderDetails)
				.HasForeignKey(o => o.OrderId);

			builder.HasOne(od => od.Product)
				.WithMany(p => p.OrderDetails)
				.HasForeignKey(od => od.ProductId);

			builder.HasCheckConstraint("CheckQuantityNotEqualZero",$@"[{nameof(OrderDetails.OrderQuantity)}] >= 0");


			builder.HasData(
				  new
				  {
                      OrderId=1,
                      ProductId=1,
                      OrderQuantity=3,
                  },
				  new
				  {
                      OrderId = 1,
                      ProductId =2,
                      OrderQuantity =2,
                  },
				  new
				  {
                      OrderId = 2,
                      ProductId =2,
                      OrderQuantity =5,
                  },
                  new
                  {
                      OrderId = 3,
                      ProductId = 2,
                      OrderQuantity = 2,
                  },
                  new
                  {
                      OrderId = 3,
                      ProductId = 5,
                      OrderQuantity = 4,
                  }


                );
        }
    }
}

