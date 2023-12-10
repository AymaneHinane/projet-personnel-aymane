using System;
using test6.DB;
using test6.Models;
using test6.Repository.GenericRepository;

namespace test6.Repository.OrderRepository
{
	public class OrderRepository:GenericRepository<Order>,IOrderRepository
	{
		public OrderRepository(DBContext context) : base(context)
		{
		}
	}
}

