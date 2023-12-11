using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test2.Models
{
	[Index(nameof(FirstName), nameof(LastName))]
	public class Employee
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string? FirstName { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string? LastName { get; set; }

		
		[Column(TypeName = "varchar(60)")]
		public string? FullName { get; set; }

		[Required]
		[Column(TypeName ="decimal(6,2)")]
		public decimal Salary { get; set; }

		
		

		[Required]
		public DateTime DateOfBirth { get; set; }

		public int EmployeeJobId { get; set; }
		public EmployeeJob? EmployeeJob { get; set; }

		public int LibraryId { get; set; }
		public Library? Library { get; set; }


		public List<Order>? Orders { get; set; }
		
	}
}

