using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models
{
	public class Product
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public int AvailableQuantity { get; set; }

		public List<OrderDetail> OrderDetails { get; set; } = new();

		public int ProductCategoryId { get; set; }
		public ProductCategory ProductCategory { get; set; }

        [Required]
        [Range(1,5)]
		public double Ranting { get; set; }
	

	}

    class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Name).HasMaxLength(60).IsRequired();
			builder.Property(p => p.Description).IsRequired(false);
			builder.HasIndex(p => p.Name);
			builder.Property(p => p.Price).HasColumnType("decimal(5,2)");
			builder.Property(p => p.AvailableQuantity).IsRequired();

			builder.HasCheckConstraint("AvailableQuantityLimitation", @$" [{nameof(Product.AvailableQuantity)}] > 0 ");


		}
    }

}

