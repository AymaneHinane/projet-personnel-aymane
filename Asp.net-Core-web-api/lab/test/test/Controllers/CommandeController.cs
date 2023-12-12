using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.DB;
using test.Models;
using test.ModelsSearch;
using test.Repository.CommandeRepository;

namespace test.Controllers
{
	[ApiController]
	[Route("api/{controller}")]
	public class CommandeController:ControllerBase
	{
		private  readonly ICommandeRepository _repository;
		private readonly DBContext _context;

		public CommandeController(ICommandeRepository repository,DBContext context)
        {
          _repository = repository;
			_context = context;
        }
        


		[HttpPost("")]
		public async Task<IActionResult> addCommande([FromBody] Commande commande)
		{
			 await _repository.AddNewCommande(commande);

			return Ok();
		}


		[HttpPost("{id}")]
		public async Task<IActionResult> addProductCommande([FromRoute]int id,[FromBody] ProductCommande productcommande)
        {
			try
			{
				await _repository.AddProductCommande(id, productcommande);
				return Ok();
			}catch(Exception e)
			{
				return BadRequest();
			}

        }

		[HttpPost("List/{id}")]
		public async Task<IActionResult> addProductsCommande([FromRoute] int id, [FromBody] List<ProductCommande> productscommande)
		{
			
				await _repository.AddProductsCommande(id, productscommande);
				return Ok();
			

		}


		[HttpGet("commandeCout/{id}")]
		public async Task<IActionResult> CountCommandeClient(int id)
        {
			var data = await _repository.CountCommandeClient(id);
			return Ok(data);
        }


		[HttpGet("ProductCommande/{id}")]
		public async Task<IActionResult> GetProductCommande(int id)
        {
			var data = await _repository.GetProductCommande(id);
			
			return Ok(data);
		}

		[HttpGet("CommandeDetails/{id}")]
		public async Task<IActionResult> GetCommandeDetails(int id)
        {
			Console.WriteLine(id);
			var data =await _repository.CommandeDetails(id);

			return Ok(data);

		}

	}
}

