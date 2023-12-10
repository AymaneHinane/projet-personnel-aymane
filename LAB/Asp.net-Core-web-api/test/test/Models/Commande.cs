using System;
namespace test.Models
{
	public class Commande
	{
		public int Id { get; set; }
		//DateTime DeliveryDate { get; set; }
		//DateTime CommandeDate { get; set; }

		public int ClientId { get; set; }
		public  Client? Client { get; set; }

		public int EmployeeId { get; set; }
		public  Employee? Employee { get; set; }

		public  ICollection<Product>? Products { get; set; }
		public  List<ProductCommande>? ProductCommandes { get; set; }
	}
}

