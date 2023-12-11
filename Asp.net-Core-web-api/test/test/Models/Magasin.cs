using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
	[Table("Magasins",Schema= "Entreprise")]
	public class Magasin
	{
		public int Id { get; set; }

		
		[MaxLength(200)]
		public string? Name { get; set; }

		public  List<Employee>? employees { get; set; }
	}
}

