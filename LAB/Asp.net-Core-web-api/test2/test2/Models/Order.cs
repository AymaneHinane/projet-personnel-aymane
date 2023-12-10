using System;
namespace test2.Models
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }

		public int LibraryId { get; set; }
		public Library? Library { get; set; }

		public int ClientId { get; set; }
		public Client? Client { get; set; }

		public List<OrderDetails>? OrderDetails { get; set; }

		public int EmployeeId { get; set; }
		public Employee? Employee { get; set; }

	}
}

