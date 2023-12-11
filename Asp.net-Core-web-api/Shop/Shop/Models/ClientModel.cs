using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
	public class ClientModel
	{
		public int Id { get; set; }
		[MaxLength(50)]
		[Required]
		public string? FirstName { get; set; }
		[MaxLength(50)]
		[Required]
		public string? LastName { get; set; }
		[Required]
		public DateTime Date_Birth { get; set; }

		public int AddressModelId { get; set; }
		public AddressModel? AddressModel { get; set; }

		public ICollection<Commande>? Commande{ get; set; }
	}
}

