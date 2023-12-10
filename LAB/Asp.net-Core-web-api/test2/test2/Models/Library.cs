using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test2.Models
{
	public class Library
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName ="varchar(50)")]
		public string? Name { get; set; }

		public Adresse? Adresse { get; set; }

		public List<Order>? Orders { get; set; }

		public List<LibraryBook>? LibraryBooks { get; set; }

		public List<Employee>? Employees { get; set; }



	}
}

