using System;
namespace Project.Entities.Models
{
	public class InvoiceCategory
	{
		public Guid Id { get; set; }
		public string? Category { get; set; }

		public ICollection<Invoice>? Invoices { get; set; } 
	}
}

