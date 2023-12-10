using System;
using test6.Models;
using test6.Repository.GenericRepository;

namespace test6.Repository.ProductRepository
{
	public interface IProductRepository: IGenericRepository<Product>
	{
	}
}

