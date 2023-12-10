using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace test1.Model.Shema2
{
	public class Order
	{
        public int OrderId;


        public int CustomerId;
        public Customer Customer;

        public ICollection<LineItem> lineItems;



    }

    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(x => x.OrderId);

            //builder.HasCheckConstraint("CK_OrderDate", @$"[{nameof(Order.DeleveryDate)}] > [{nameof(Order.OrderDate)}]");




        }
    }



}

