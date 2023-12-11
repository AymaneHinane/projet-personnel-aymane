using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test1.Model.Shema2
{
	public class Author
	{
		public int AuthorId;
		public string Name;

       
        public ICollection<BookAuthor> BookAuthors;

    }

    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

          
        }
    }
}

