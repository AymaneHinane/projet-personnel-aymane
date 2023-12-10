using System;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
	//[Keyless]
	public class CommandeProduct
	{

		public int Id { get; set; }

		public int CommandeId { get; set; }
		public Commande? Commande { get; set; }
		public int ProductId { get; set; }
		public Product? Product { get; set; }

		public int quantity { get; set; }
	}
}

