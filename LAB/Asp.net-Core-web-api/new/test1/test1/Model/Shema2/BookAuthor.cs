using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test1.Model.Shema2
{
	public class BookAuthor
	{
		public int AuthorId;
		public Author Author;

		public int BookId;
		public Book Book;
	}

    public class BookAuthorEntityTypeConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => new { x.AuthorId, x.BookId });

            builder
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors);

            builder
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors);
        }
    }
}

