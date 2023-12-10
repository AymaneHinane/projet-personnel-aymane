using System;
using test6.DB;
using test6.Models;
using test6.Repository.GenericRepository;

namespace test6.Repository.ProductRepository
{
	public class ProductRepository:GenericRepository<Product>,IProductRepository
	{
		public ProductRepository(DBContext context) : base(context)
		{
		}
	}
}

