using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace test.Models
{
	[Index(nameof(FirstName),nameof(LastName),IsUnique =true)]
	public class Client
	{
		public int Id { get; set; }
		[Required,MaxLength(50)]
		public string? FirstName { get; set; }
		[Required, MaxLength(50)]
		public string? LastName { get; set; }

		[MaxLength(100)]
		public string? DisplayName { get; set; }

        public  List<Commande>? Commande { get; set; }
	}
}

