using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test1.Model.Shema2
{
	    enum BookCategories
	    {
            Adventure,
            stories,
            Classics,
            Crime,
            Fairy_tales,
            fables,
            Fantasy,
            Historical,
            Horror,
            Humour,
            fiction,
            Mystery,
            Poetry,
            Plays,
            Romance,
            Science_fiction,
            Short_stories,
            Thrillers,
            War,
        }

    public class Category
	{
		int CategoryId;

        BookCategories BookType;

        public int BookId;
        public ICollection<Book> Book;
    }


    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.BookId);

            builder.HasMany(c => c.Book)
                .WithMany(b => b.Categories);
                

        }
    }
}

