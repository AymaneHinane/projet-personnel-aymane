using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test8.Model.Shop
{
	public enum City
	{
		casablanca,
		rabat,
		fes,
		agadir,
		marakech,
		tanger
	}

	public class ShippingAdresse
	{
		public int Id { get; set; }
		public City City { get; set; }
		//public string Country { get; set; }
		public int ZipCode { get; set; }

		public int OrderId { get; set; }
		public Order? Order { get; set; }
	}


    public class ShippingAdresseEntityTypeConfiguration : IEntityTypeConfiguration<ShippingAdresse>
    {
        public void Configure(EntityTypeBuilder<ShippingAdresse> builder)
        {
			builder.HasKey(sa=>sa.Id);

			 builder.Property(sa => sa.City).HasConversion<string>();
			//builder.Property(sa => sa.City).HasConversion(
			//	   v=>v.ToString(),
			//	   v=>(City)Enum.Parse(typeof(City),v)
            //);


			builder.Property<string>("Country").HasDefaultValue("Maroc");
			builder.HasCheckConstraint("CheckZipCode", $@"[{nameof(ShippingAdresse.ZipCode)}] between 100 and 9999");

			builder.HasData(
                     new { Id = 1, City = City.casablanca, ZipCode = 4000, OrderId = 1 },
                    new { Id = 2, City = City.casablanca, ZipCode = 6000, OrderId = 2 },
                    new { Id = 3, City = City.rabat, ZipCode = 2000, OrderId = 3 }
                );
        }
    }

}
	
