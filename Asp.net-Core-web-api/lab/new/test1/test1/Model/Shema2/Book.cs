using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test1.Model.Shema2
{
	public class Book
	{
		public int BookId;
		public string Title;
		public string Description;
		public DateTime PublishedOn;

        public PriceOffers PriceOffers;
        public ICollection<Review> Review;
		public ICollection<BookAuthor> BookAuthors;
        public ICollection<Category> Categories;
        public ICollection<LineItem> lineItems;


    }

    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);

            builder
              .HasMany(p => p.Review)
              .WithOne(r => r.Book)
              .HasForeignKey(p => p.BookId);

            builder
                 .HasOne(b => b.PriceOffers)
                 .WithOne(p => p.Book)
                 .HasForeignKey<PriceOffers>(p => p.BookId);

            builder.HasMany(b => b.Categories)
                .WithMany(c => c.Book);
        }
    }
}

