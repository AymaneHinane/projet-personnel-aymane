using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models
{
	public class Order
	{
		public int Id { get; set; }

		public int ClientId { get; set; }
		public Client Client { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime DeliveryDate { get; set; }

		public int StorId { get; set; }
		public Store Store { get; set; }

		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }


		public List<OrderDetail> OrderDetails { get; set; } = new();
	}

    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
			builder.HasKey(o => o.Id);

			builder.Property(o => o.OrderDate).HasDefaultValueSql("GETDATE()");

			builder.HasCheckConstraint("CheckOrderDate", @$"[{nameof(Order.DeliveryDate)}] > [{nameof(Order.OrderDate)}]");


        }
    }
}

