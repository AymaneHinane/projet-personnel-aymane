using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model.Shop
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }


        public List<OrderDetails>? OrderDetails { get; set; }

        public int AvailableQuantity { get; set; }

        public int productCategoryId { get; set; }
        public ProductCategory productCategory { get; set; }

        public ICollection<ProductPropertyValue> productPropertiesValue { get; set; }

        
        public decimal Price { get; set; }
    }


    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.Price).HasColumnType("money");

            builder.HasCheckConstraint("CK_AvailableQuantity", $@"[{nameof(Product.AvailableQuantity)}] >= 0");


            //1 book    2 phone  3 laptop
            builder.HasData(
                new
                {
                    Id = 1,
                    Name = "hp omen 15",
                    AvailableQuantity=22,
                    productCategoryId = 3,
                    Price=18000m
                },
                new
                {
                    Id = 2,
                    Name = "asus 15",
                    AvailableQuantity = 11,
                    productCategoryId = 3,
                    Price=15000m
                },
                new
                {
                    Id = 3,
                    Name = "s22",
                    AvailableQuantity = 46,
                    productCategoryId = 2,
                    Price=6000m
                },
                new
                {
                    Id = 4,
                    Name = "ihone 12",
                    AvailableQuantity = 17,
                    productCategoryId = 2,
                    Price=7500m
                },
                new
                {
                    Id = 5,
                    Name = "noelle",
                    AvailableQuantity = 80,
                    productCategoryId = 1,
                    Price=120m
                }
                );
        }
    }
}

