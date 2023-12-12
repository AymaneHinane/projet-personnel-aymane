using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test2.Models
{
	
	public class Category
	{

		public int Id { get; set; }
		[Required]
		[Column(TypeName ="varchar(50)")]
		public string? Name { get; set; }


		public List<Book>? Books { get; set; }
	}
}

