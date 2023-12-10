using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test.Models
{

	[Index(nameof(Name),IsUnique =true,Name ="Index_Category_Name")]
	public class Category
	{
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required,MaxLength(60)]
		public string? Name { get; set; }


		public  List<Product>? Product { get; set; }
	}
}

