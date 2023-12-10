using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models
{
	public class Address
	{
		public int Id { get; set; }

		public string City { get; set; }= string.Empty;

		public string Country { get; set; }=string.Empty;

		public int ZipCode { get; set; }

        
		public int ClientId { get; set; }
		public Client? Client { get; set; }

	}

    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
			builder.HasKey(a => a.Id);
			builder.Property(a => a.City).HasMaxLength(50).IsRequired();
			builder.Property(a => a.Country).HasMaxLength(50).IsRequired();

			
			builder.HasCheckConstraint("CheckCountry", $@"[{nameof(Address.Country)}] = 'Maroc'");
            builder.HasCheckConstraint("CheckCity", $@"[{nameof(Address.City)}] in ('Casa','Rabat','Marakech','Tanger','Fes')");
            builder.HasCheckConstraint("CheckZipCode", $@"[{nameof(Address.ZipCode)}] > 10000");

			//builder.HasData(
			//	   new Address { Id = 1, City = "Casa", Country = "Maroc", ZipCode = 210000, ClientId = 1 }
			//	);
		}
    }
}

