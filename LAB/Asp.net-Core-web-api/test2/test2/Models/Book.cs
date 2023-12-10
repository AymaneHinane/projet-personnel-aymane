using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test2.Models
{
	[Index(nameof(Name))]
	public class Book
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string? Name { get; set; }

		[Required]
		public int quantity { get; set; }

		[Required]
		[Column(TypeName = "decimal(5, 2)")]
		public double Price { get; set; }


		public int AuthorId { get; set; }
		public Author? Author { get; set; }

		public int CategoryId { get; set; }
		public Category? Category { get; set; }

		public List<OrderDetails>? OrderDetails { get; set; }

		public List<LibraryBook>? LibraryBooks { get; set; }
	}
}

