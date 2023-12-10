using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models.ProductDescription
{
	public enum ElectronicsCategoryEnum
    {
		Phone,
		Laptop,
		IPad,
    }

	public class Electronics:Product
	{
		public ElectronicsCategoryEnum ElectronicsCategory { get; set; }
		public int Ram { get; set; }
		public int Storage { get; set; }
		public int ScreenSize { get; set; }
	}

	public class ElectronicsEntityTypeConfiguration : IEntityTypeConfiguration<Electronics>
	{


        public void Configure(EntityTypeBuilder<Electronics> builder)
        {
			builder.Property(c => c.ElectronicsCategory).HasConversion<string>();
			builder.HasBaseType<Product>();
		}
    }
}

