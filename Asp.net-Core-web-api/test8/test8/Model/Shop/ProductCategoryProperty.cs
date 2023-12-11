using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model.Shop
{
	public class ProductCategoryProperty
	{

		public int ProductCategoryId { get; set; }
		public ProductCategory productCategory { get; set; }

		public int ProductPropertyId { get; set; }
		public ProductProperty productProperty { get; set; }  

    }

    public class ProductCategoryPropertyEntityTypeConfiguration : IEntityTypeConfiguration<ProductCategoryProperty>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryProperty> builder)
        {
            builder.HasKey(x => new { x.ProductCategoryId, x.ProductPropertyId });

            builder.HasOne(pcp => pcp.productCategory)
                .WithMany(pc => pc.productCategoryProperties)
                .HasForeignKey(pcp => pcp.ProductCategoryId);

            builder.HasOne(pcp => pcp.productProperty)
                .WithMany(pp => pp.productCategoryProperties)
                .HasForeignKey(pcp => pcp.ProductPropertyId);

            builder.HasData(
                new
                {
                    ProductCategoryId = 3,
                    ProductPropertyId = 1
                },
                new
                {
                    ProductCategoryId =3,
                    ProductPropertyId = 2,
                },
                new
                {
                    ProductCategoryId = 3,
                    ProductPropertyId = 3,
                },
                new
                {
                    ProductCategoryId = 3,
                    ProductPropertyId =4 
                },
                new
                {
                    ProductCategoryId = 3,
                    ProductPropertyId = 5
                },
                new
                {
                    ProductCategoryId = 3,
                    ProductPropertyId = 6
                },
                new
                {
                    ProductCategoryId = 3,
                    ProductPropertyId = 7
                },
                new
                {
                    ProductCategoryId = 3,
                    ProductPropertyId = 9
                },
                new
                {
                    ProductCategoryId = 3,
                    ProductPropertyId = 12
                },
                new
                {
                    ProductCategoryId = 2,
                    ProductPropertyId = 1
                },
                new
                {
                    ProductCategoryId = 2,
                    ProductPropertyId = 7
                },
                new
                {
                    ProductCategoryId = 2,
                    ProductPropertyId = 9
                },
                new
                {
                    ProductCategoryId = 2,
                    ProductPropertyId = 13
                },
                new
                {
                    ProductCategoryId = 2,
                    ProductPropertyId = 14
                },
                new
                {
                    ProductCategoryId = 2,
                    ProductPropertyId = 12
                },

                new
                {
                    ProductCategoryId = 1,
                    ProductPropertyId = 10
                },
                new
                {
                    ProductCategoryId = 1,
                    ProductPropertyId = 11
                },
                new
                {
                    ProductCategoryId = 1,
                    ProductPropertyId =12
                }
               );


        }
    }
}

