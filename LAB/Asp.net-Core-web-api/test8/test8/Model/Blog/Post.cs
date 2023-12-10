using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model
{
	public class Post
	{
        
            public int Id { get; set; }
            public string Title { get; set; }
            public string Article { get; set; }
            public int BlogId { get; set; }
            public Blog Blog { get; set; }
    }

    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(50);
            builder.Property(p => p.Article).HasMaxLength(400);

            builder.HasData(
                     new
                     {
                         Id=1,
                         Title="seremonie 1",
                         Article="no article",
                         BlogId=1,
                         CreateDate = DateTime.Now,
                         UpdateDate = (DateTime?)null
                     },
                     new
                     {
                         Id = 2,
                         Title = "seremonie 2",
                         Article = "no article",
                         BlogId = 1,
                         CreateDate = DateTime.Now,
                         UpdateDate = (DateTime?)null
                     },
                     new
                      {
                          Id = 3,
                          Title = "minasia",
                          Article = "no article",
                          BlogId = 2,
                          CreateDate = DateTime.Now,
                          UpdateDate = (DateTime?)null
                      }
                 );
        }


    }
}

