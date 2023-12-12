using System;
using System.ComponentModel.DataAnnotations;

namespace test.ModelsSearch
{
	public class CommandeDetails
	{
		[Key]
		public int ClientId{get;set;}
		public string DisplayName { get; set; }
		public int CommandeId { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
	}
}

