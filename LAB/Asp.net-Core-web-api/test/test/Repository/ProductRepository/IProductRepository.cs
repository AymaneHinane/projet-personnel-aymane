using System;
using test.Models;
using test.ModelsSearch;

namespace test.Repository.ProductRepository
{
	public interface IProductRepository:IGenericRepository<Product>
	{
		Task<List<Product>> GetProductByCategorie(string categorie);
		Task<Product> GetProductByName(string Name);
		Task<Product> Add(Product product, string category);
		Task<ProductInfo> GetById(int id);
	}
}

