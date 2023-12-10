using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test.Models
{
	public class User
	{
	    public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
	    public string LastName { get; set; } = string.Empty;
		public string ContactEmailAddresse { get; set; } = string.Empty;
	}


    public class UserTypeEntityConfiguration : IEntityTypeConfiguration<User>
    {
        

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(150);
            builder.HasKey(u => u.Id);
        }
    }
}

