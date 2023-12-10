using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace test2.Models
{

	
	public class Adresse
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string? City { get; set; }

		[Required]
		[Column(TypeName = "varchar(50)")]
		public string? Area { get; set; }

		public int LibraryId { get; set; }
		public Library? Library { get; set; }

		public int ClientId { get; set; }
		public Client? Client { get; set; }

	

	}
}

