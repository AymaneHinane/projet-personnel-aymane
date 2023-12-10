using System;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
	public class ProductImage
	{
		public int Id { get; set; }
		public byte[]? Image { get; set; }
		[MaxLength(200)] 
		public string? Name { get; set; }

		public int ProductId { get; set; }
		public Product? Product { get; set; }
	}
}

