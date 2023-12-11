using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace test.Models
{

	[Index(nameof(Name))]
	public class Product
	{
        //[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(60)]
		public string Name { get; set; }

		[Required]
		
		public decimal price { get; set; }

		[Required]
		public int Quantity { get; set; }
		
		public DateTime? AddDepot { get; set; }

		
		public  ProductImage? ProductImage { get; set; }

		public int CategoryId { get; set; }
		public  Category? Category { get; set; }


		public  ICollection<Commande>? Commandes { get; set; }
		public  List<ProductCommande>? ProductCommandes { get; set; }
	}
}

