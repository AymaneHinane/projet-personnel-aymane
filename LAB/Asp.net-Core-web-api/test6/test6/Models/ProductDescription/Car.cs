using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models.ProductDescription
{
	public enum CarCategoryEnum
    {
		BMW,
		Audi,
		Mercedes,
		Dacia,
		Toyota
    }

	public enum EngineTypeEnum
    {
		essence,
		diesel,
		Hybride
    }

	public class Car : Product
	{
		public CarCategoryEnum CarCategory { get; set; }
		public bool Fuel_Economy { get; set; }
		public EngineTypeEnum EngineType {get;set;}
	}

    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
			builder.Property(c => c.CarCategory).HasConversion<string>();
			builder.Property(c => c.EngineType).HasConversion<string>();
			builder.HasBaseType<Product>();
        }
    }
}

