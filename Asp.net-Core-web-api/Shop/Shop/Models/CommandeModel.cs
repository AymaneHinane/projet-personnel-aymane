using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
	public class Commande
	{
		public int CommandeId { get; set; }
		[Required]
		public DateTime Delivery_date { get; set; }
		[Required]
		public DateTime Order_date { get; set; }
        public ClientModel? Client { get; set; }

		public List<CommandeProduct>? CommandeProduct { get; set; }

	}
}

