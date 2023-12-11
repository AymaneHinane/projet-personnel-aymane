using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models
{
	public class Client
	{
		public int Id { get; set; }

		public string FirstName { get; set; } = string.Empty;
		
		public string LastName { get; set; } = string.Empty;

		public string? EmailAddress { get; set; } = string.Empty;

		//[JsonIgnore]
		public Address Address { get; set; }
	

		public List<Order>? Orders { get; set; }
	}


    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
			builder.HasKey(u => u.Id);
			builder.Property(u => u.FirstName).HasMaxLength(30).IsRequired();
			builder.Property(u => u.LastName).HasMaxLength(30).IsRequired();
			builder.Property(u => u.EmailAddress).HasMaxLength(60).IsRequired(false);

			builder.HasIndex(u => u.FirstName ).IsUnique();
			builder.HasIndex(u => u.EmailAddress).IsUnique();

			builder.HasOne(c => c.Address)
				.WithOne(a => a.Client)
				.HasForeignKey<Address>(a => a.ClientId);

			builder.HasMany(u => u.Orders)
				.WithOne(o => o.Client)
				.HasForeignKey(o => o.ClientId)
				.OnDelete(DeleteBehavior.NoAction);

			//builder.HasData(
			//	   new Client
			//	   {
			//		   Id=1,
			//		   FirstName = "hinane",
			//		   LastName = "aymane",
			//		   EmailAddress = "aymanehinane@gmail.com"
			//	   }
			//	);
        }
    }

	public class ClientInfo
	{
		public int Id { get; set; }

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

	}
}

