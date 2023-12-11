
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test6.Models
{
	public class Employee
	{
		public int Id { get; set; }

		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public decimal Salary { get; set; }

		public int StoreId { get; set; }
		public Store Store { get; set; }

		public List<Order> Orders { get; set; }
	}

    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
			builder.HasKey(e => e.Id);
			builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
			builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
			builder.HasIndex(e => e.FirstName).IsUnique();
			builder.Property(e => e.Salary).HasColumnType("decimal(5,2)");

			builder.HasMany(e => e.Orders)
				.WithOne(o => o.Employee)
				.HasForeignKey(o => o.EmployeeId)
				.OnDelete(DeleteBehavior.NoAction);
        }
    }
}

