using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models
{
	public enum CategoryEnum
    {
		Book,
		Clothes,
		Electronics,
		Car
	}

	public class ProductCategory
	{
		public int Id { get; set; }

		public CategoryEnum Category { get; set; }

		public List<Product> Products { get; set; } = new();
	}

    public class ProductCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
			builder.HasKey(pc => pc.Id);
			builder.Property(pc => pc.Category).HasConversion<string>();

			builder.HasMany(pc => pc.Products)
				.WithOne(p => p.ProductCategory)
				.HasForeignKey(p => p.ProductCategoryId)
				.OnDelete(DeleteBehavior.NoAction);
        }
    }
}

