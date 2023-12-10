using System;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
using test.DB;
using test.Models;
using test.ModelsSearch;
using test.Repository.ProductRepository;

namespace test.Repository.ClientRepository
{
	public class ProductRepository: GenericRepository<Product>,IProductRepository
	{

		private readonly  DBContext _context;

		public ProductRepository(DBContext context) : base(context) => _context = context;




        public async Task<Product> Add(Product product, string category)
        {
            if (_context != null)
            {
                var Category = await _context.Categories
                    .Where(c => c.Name == category)
                     .Select(c => new {Id=c.Id })
                    .FirstOrDefaultAsync();


                if (Category != null)
                {
                    product.CategoryId = Category.Id;
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();

                    return product;
                }
            }
            
                return null;

        }

        public  async Task<ProductInfo> GetById(int id)
        {
            
                var search = await _context.Products.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefaultAsync();

                if (search != null)
                {
                    var data = new ProductInfo()
                    {
                        id = search.Id,
                        name = search.Name,
                        price = search.price,
                        category = search.Category.Name
                    };
                    return data;
                }

                return null;
          
            
        }



        public new async Task<List<Product>> GetAll()
        {
            
            if (_context.Products != null)
            {
                 var data = await _context.Products
                        .ToListAsync();

                return data;
            }
            return null;
        }

        public async Task<List<Product>> GetProductByCategorie(string category)
            {

                if (_context != null)
                {

                    var Category = await _context.Categories
                        .Where(c => c.Name == category)
                        .Select(c => new { Id = c.Id })
                        .FirstAsync();

                        if(Category != null && _context.Products != null )
                        {
                           var products = await _context.Products
                            .Where(p => p.Category != null && p.Category.Name == category )
                            .ToListAsync();

                            return products;
                        }
                                 
                }

                return null;
            }



        public async Task<Product> GetProductByName(string Name)
        {
            if(_context != null && _context.Products != null)
            {
                var product = await _context.Products.Where(p => p.Name == Name).FirstAsync();
                if (product != null)
                    return product;
            }
            return null;
        }



    }
}

