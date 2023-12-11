using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test1.Model.Shema2
{
	public class LineItem
	{
        public int OrderQuantity { get; set; }

        public int OrderId;
        public Order Order;

        public int BookId;
        public Book Book;
    }

	public class LineItemEntityTypeConfiguration:IEntityTypeConfiguration<LineItem>
	{


        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(x => new { x.BookId, x.OrderId });

            builder.HasCheckConstraint("CheckQuantityNotEqualZero", $@"[{nameof(LineItem.OrderQuantity)}] >= 0");

            builder.HasOne(li => li.Book).WithMany(b => b.lineItems);
            builder.HasOne(li => li.Order).WithMany(o => o.lineItems);

        }


    }
}

