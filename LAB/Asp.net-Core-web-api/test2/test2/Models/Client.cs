using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test2.Models
{
	[Index(nameof(FirstName),nameof(LastName))]
	public class Client
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName ="varchar(50)")]
		public string? FirstName { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string? LastName { get; set; }

		
		[Column(TypeName = "varchar(60)")]
		public string? FullName { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		//public int AdresseId { get; set; }
		//public Adresse? Adresse { get; set; }

		public List<Order>? Orders { get; set; }

		public Adresse? Adresse { get; set; }

	}
}

