using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Linq;

namespace test8.Model.Shop
{
	public class ProductPropertyValue
	{

        public int ProductPropertyId { get; set; }
        public ProductProperty ProductProperty { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }

        public string Value { get; set; }


    }

    public class ProductPropertyValueEntityTypeConfiguration : IEntityTypeConfiguration<ProductPropertyValue>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyValue> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.ProductPropertyId });

            builder.HasOne(ppv => ppv.product)
                .WithMany(p => p.productPropertiesValue)
                .HasForeignKey(ppv => ppv.ProductId);

            builder.HasOne(ppv => ppv.ProductProperty)
                .WithMany(pp => pp.productPropertyValue)
                .HasForeignKey(ppv => ppv.ProductPropertyId);


            builder.HasData(
                new {
                    ProductId=1,
                    ProductPropertyId=1,
                    Value="15"
                    },
                new
                  {
                    ProductId =1,
                    ProductPropertyId =2,
                    Value = "i7 10gen",
                  },
                new
                {
                    ProductId = 1,
                    ProductPropertyId = 3,
                    Value = "intel",
                },
                new
                {
                    ProductId = 1,
                    ProductPropertyId = 4,
                    Value = "nvidia",
                },
                new
                {
                    ProductId = 1,
                    ProductPropertyId = 5,
                    Value = "rtx 2060",
                },
                new
                {
                    ProductId = 1,
                    ProductPropertyId = 6,
                    Value = "ssd m.2",
                },
                new
                {
                    ProductId = 1,
                    ProductPropertyId = 7,
                    Value = "1To",
                },
                new
                {
                    ProductId =1 ,
                    ProductPropertyId = 9,
                    Value = "16Go",
                },
                new
                {
                    ProductId = 1,
                    ProductPropertyId = 12,
                    Value = "hp",
                },


                new
                {
                     ProductId = 2,
                     ProductPropertyId = 1,
                     Value = "16"
                },
                new
                {
                    ProductId = 2,
                    ProductPropertyId = 2,
                    Value = "amd ryzen 5",
                },
                new
                {
                    ProductId = 2,
                    ProductPropertyId = 3,
                    Value = "amd",
                },
                new
                {
                    ProductId = 2,
                    ProductPropertyId = 4,
                    Value = "amd",
                },
                new
                {
                    ProductId = 2,
                    ProductPropertyId = 5,
                    Value = "amd 6650",
                },
                new
                {
                    ProductId = 2,
                    ProductPropertyId = 6,
                    Value = "hdd",
                },
                new
                {
                    ProductId = 2,
                    ProductPropertyId = 7,
                    Value = "550go",
                },
                new
                {
                    ProductId = 2,
                    ProductPropertyId = 9,
                    Value = "16Go",
                },
                new
                {
                    ProductId = 2,
                    ProductPropertyId = 12,
                    Value = "asus",
                },


                new
                {
                    ProductId = 5,
                    ProductPropertyId =10,
                    Value ="zack maid",
                },
                new
                {
                    ProductId = 5,
                    ProductPropertyId = 11,
                    Value = "action",
                }


                ); 
        }
    }
}

