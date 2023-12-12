using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test.Models
{

	[Table("Employees",Schema="Entreprise")]
	public class Employee
	{
		public int Id { get; set; }

		[Required]
		[Column("FirstName",TypeName ="varchar(60)")]
		public string? FirstName { get; set; }

		[Required]
		[Column("LastName", TypeName = "varchar(60)")]
		public string? LastName { get; set; }

		[Required]
		public double Salary { get; set; }

		//[NotMapped]
		public int? MagasinId { get; set; }
		public  Magasin? Magasin { get; set; }
	}
}

