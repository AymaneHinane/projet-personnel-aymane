using System;
using System.Numerics;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model
{
	public class Author
	{
		public int Id { get; set; }

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

        //[JsonIgnore]
        public List<Blog> Blogs { get; set; } = new List<Blog>();
	}


    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(30).IsRequired();

            builder.HasMany(a => a.Blogs)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
                //.IsRequired();

            //builder.HasData(new Object[]{
            //    new Author() { Id = 1, FirstName = "yan", LastName = "Maxim" }
            //});

            builder.HasData(//, UpdateDate = default(DateTime)
                new {
                    Id = 1,
                    FirstName = "yan",
                    LastName = "Maxim",
                    CreateDate = DateTime.Now,
                    UpdateDate= (DateTime?) null
                },
                new {
                    Id = 2,
                    FirstName = "han",
                    LastName = "axim",
                    CreateDate = DateTime.Now,
                    UpdateDate = (DateTime?) null
                },
                new {
                    Id = 3,
                    FirstName = "jan",
                    LastName = "amine",
                    CreateDate = DateTime.Now,
                    UpdateDate = (DateTime?) null
                }
            );
        }
    }
}

