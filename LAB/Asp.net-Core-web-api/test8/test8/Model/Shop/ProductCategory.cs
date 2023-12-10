using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model.Shop
{
	public class ProductCategory
	{

		public int Id { get; set; }
		public string CategoryName { get; set; }

        public ICollection<ProductCategoryProperty> productCategoryProperties { get; set; }


        public List<Product> products { get; set; }
	}

    public class ProductCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasMany(pc => pc.products)
                .WithOne(p => p.productCategory)
                .HasForeignKey(p=>p.productCategoryId);

            builder.HasData(
               new
               {
                   Id = 1,
                   CategoryName = "book"
               },
               new
               {
                   Id = 2,
                   CategoryName = "phone"
               },
               new
               {
                   Id = 3,
                   CategoryName = "laptop"
               }
             );
        }
    }
}

