using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
	public class AddressModel
	{
		public int Id {get;set;}
		[MaxLength(50)]
		[Required]
		public string? city { get; set; }
		[MaxLength(50)]
		[Required]
		public string? area { get; set; }
		[MaxLength(50)]
		[Required]
		public string? Country { get; set; }  
		[MaxLength(20)]
		[Required]
		public string? Primary_phone { get; set; }
		[MaxLength(20)]
		public string? Secondary_phone { get; set; }

		public ClientModel? ClientModel { get; set; }
	}
}

