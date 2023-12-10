using System;
using test8.Model.Library;

namespace tp9.Library
{
	public class Orders
	{
		public int Id { get; set; }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }

		
		public DateTime DateOrderedUtc { get; set; }

        public ICollection<LineItem>? lineItems { get; set; }
    }
}

