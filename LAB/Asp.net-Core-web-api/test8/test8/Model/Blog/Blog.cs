using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;




namespace test8.Model
{

 //[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlogCategorie
{
    action,
	romance,
	horour,
	love,
    science
}
	public class Blog
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

       // [JsonConverter(typeof(JsonStringEnumConverter))]
        public BlogCategorie categorie { get; set; }

        // public decimal Rating { get; set; }

        
        public int AuthorId { get; set; }
        public Author Author { get; set; } = new Author();

        public List<Post> Posts { get; set; }

    }



    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(30).IsRequired();
            builder.Property(b => b.categorie).HasConversion<string>();

            //builder.Property(b => b.categorie).HasConversion(
            //   v => v.ToString(),
            //   v =>  (BlogCategorie)Enum.Parse(typeof(BlogCategorie), v)
            //);

            // builder.Property(b => b.Rating).HasColumnType("decimal(2,1)");


            //builder.Property<DateTime>("UpdateDate").HasDefaultValueSql("getdate()");
            //builder.Property<DateTime>("CreateDate");

            builder.HasMany(b => b.Posts)
                .WithOne(p => p.Blog)
                .HasForeignKey(b => b.BlogId);


            builder.HasData(
                 new  {
                     Id = 1,
                     AuthorId = 1,
                     Name = "hello world",
                     categorie = BlogCategorie.science,
                     CreateDate = DateTime.Now,
                     UpdateDate = (DateTime?)null
                 },
                new  {
                    Id = 2,
                    AuthorId = 1,
                    Name = "life is good",
                    categorie = BlogCategorie.romance,                   
                    CreateDate = DateTime.Now,
                    UpdateDate = (DateTime?)null
                },
                new  {
                    Id = 3,
                    AuthorId = 2,
                    Name = "wolf",
                    categorie = BlogCategorie.horour,
                    CreateDate = DateTime.Now,
                    UpdateDate = (DateTime?)null
                },
                new  {
                    Id = 4,
                    AuthorId = 2,
                    Name = "docker",
                    categorie = BlogCategorie.science,
                    CreateDate = DateTime.Now,
                    UpdateDate = (DateTime?)null
                }
                );
        }
    }
}

