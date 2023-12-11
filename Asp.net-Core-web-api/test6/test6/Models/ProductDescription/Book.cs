using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models.ProductDescription
{
	public enum BookCategoryEnum
	{
		Classic_Literature,
		THRILLER,
		Psychology,
		MANUAL,
		Self_Improvement,
		Manga
	}

	public class Book : Product
	{
		public string Author { get; set; } = string.Empty;
		public BookCategoryEnum BookCategory { get; set; }
	}

    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
			builder.Property(a => a.Author).HasMaxLength(50).IsRequired();
			builder.Property(a => a.BookCategory).HasConversion<string>();
			builder.HasBaseType<Product>();			
        }
    }
}

