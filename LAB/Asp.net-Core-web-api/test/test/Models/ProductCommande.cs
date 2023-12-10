using System;
namespace test.Models
{
	public class ProductCommande
	{
		public DateTime PublicationDate { get; set; }
		public int Quantity { get; set; }

		public int ProductId { get; set; }
        public Product? Product { get; set; }

		public int CommandeId { get; set; }		
		public Commande? Commande { get; set; }

	}
}

