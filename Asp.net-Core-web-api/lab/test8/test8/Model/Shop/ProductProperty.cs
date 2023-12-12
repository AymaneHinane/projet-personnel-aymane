
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model.Shop
{
	public class ProductProperty
	{
		public int Id { get; set; }
		public string PropertyName { get; set; }

        public ICollection<ProductCategoryProperty> productCategoryProperties { get; set; }
        public ICollection<ProductPropertyValue> productPropertyValue { get; set; }


    }

    public class ProductPropertyEntityTypeConfiguration : IEntityTypeConfiguration<ProductProperty>
    {
        public void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            builder.HasData(
             new 
             {
                 Id = 1,
                 PropertyName = "screen_size",
             },
             new
             {
                 Id = 2,
                 PropertyName = "cpu_version",
             },
             new
             {
                 Id = 3,
                 PropertyName = "cpu_type"
             },
              new
              {
                  Id = 4,
                  PropertyName = "gpu_type",
              },
               new
               {
                   Id = 5,
                   PropertyName = "gpu_version",
               },
             new
             {
                 Id = 6,
                 PropertyName = "storage_type",
             },
             new
             {
                 Id = 7,
                 PropertyName = "storage",
             },
             new
             {
                 Id = 9,
                 PropertyName = "ram_storage"
             },
             new
             {
                 Id = 10,
                 PropertyName = "author"
             },
              new
              {
                  Id = 11,
                  PropertyName = "book_category"
              },
              new
              {
                  Id = 12,
                  PropertyName = "mark"
              },
              new
              {
                  Id = 13,
                  PropertyName = "arm_type"
              },
              new
              {
                  Id = 14,
                  PropertyName = "arm_version"
              }
              );

        }
    }
}

