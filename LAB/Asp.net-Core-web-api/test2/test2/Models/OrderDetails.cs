using System;
using System.ComponentModel.DataAnnotations;

namespace test2.Models
{
	public class OrderDetails
	{
		public int OrderId { get; set; }
		public Order? Order { get; set; }

        public int BookId { get; set; }
		public Book? Book { get; set; }

		[Required]
		public int quantity { get; set; }

		public double Total { get => this.Book!.Price * this.quantity; }

	}
}

