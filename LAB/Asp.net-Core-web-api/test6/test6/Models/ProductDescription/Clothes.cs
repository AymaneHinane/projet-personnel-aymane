using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models.ProductDescription
{
	public enum ClothesCategoryEnum
    {
		shoe,
		pants,
		t_shirts
	}

	public enum MarkEnum
    {
		Adidas,
		Nike,
		Lacoste
	}

	public enum ClothesSizeEnum
	{
		S,
		M,
		XL,
		XXL
    }

	public class Clothes : Product
	{
		public ClothesCategoryEnum ClothesCategory { get;set;}
		public MarkEnum Mark { get; set; }
		public ClothesSizeEnum? clothesSize { get; set; }
		public int Size { get; set; } 
	}

	public class ClothesEntityTypeConfiguration : IEntityTypeConfiguration<Clothes>
	{


        public void Configure(EntityTypeBuilder<Clothes> builder)
        {
			builder.Property(c => c.ClothesCategory).HasConversion<string>();
			builder.Property(c => c.Mark).HasConversion<string>();
			builder.Property(c => c.clothesSize).HasConversion<string>();
			builder.HasBaseType<Product>();
        }
    }
}