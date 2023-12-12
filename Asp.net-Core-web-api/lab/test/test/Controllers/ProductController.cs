using System;
using Microsoft.AspNetCore.Mvc;
using test.DB;
using test.Models;
using test.Repository.ProductRepository;

namespace test.Controllers
{
	[ApiController]
	[Route("api/{controller}")]
	public class ProductController:ControllerBase
	{
		private readonly IProductRepository _productRepository;
		public ProductController(IProductRepository productRepository) => _productRepository = productRepository;


		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct([FromRoute]int id)
		{
			try
			{
				//Console.WriteLine($"id is {id}");
				var data = await _productRepository.GetById(id);

				if (data != null)
					return Ok(data);
				else
					return NotFound();
			}
			catch (Exception e)
			{
				return BadRequest();
			}

		}


		[HttpGet("")]
		public async Task<IActionResult> GetAllProduct()
        {
			try
			{
				var data = await _productRepository.GetAll();
			
				if (data != null)
					return Ok(data);
				else
					return NotFound();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
			
        }

		[HttpPost("{category}")]
		public async Task<IActionResult> AddProduct([FromBody] Product product,[FromRoute] string category)
        {
			
				Console.WriteLine("\n i'm here 1 \n");
				var data =await _productRepository.Add(product, category);

				if (data != null)
					return Ok(data);

            

			return NotFound();
        }


		[HttpGet("GetProductCat/{category}")]
		public async Task<IActionResult> AddProduct([FromRoute] string category)
		{

			try
			{
				
				var data = await _productRepository.GetProductByCategorie(category);

				if (data != null)
					return Ok(data);

				return NotFound();
			}catch(Exception e)
            {
				return BadRequest();
            }
		}




	}
}

