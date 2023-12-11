using System;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repository.ClientRepository;

namespace test.Controllers
{
	[Route("api/{controller}")]
	[ApiController]
	public class ClientController:ControllerBase
	{

		private readonly IClientRepository _repository;
		public ClientController(IClientRepository repository) => _repository = repository;


		[HttpGet("")]
		public async Task<IActionResult> getAllClient()
		{
			try
			{
				var data = await _repository.GetAll();

				if (data != null)
					return Ok(data);
				else
					return NotFound();
			}catch(Exception e)
            {
				return BadRequest();
            }
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> getClient(int id)
		{
			try
			{
				var data = await _repository.Get(id);

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


		[HttpPost("")]
		public async Task<IActionResult> AddClient(Client client)
		{
			try
			{
				var data = await _repository.Add(client);
				return Ok(data);
		    }
			catch (Exception e)
			{
				return BadRequest();
			}
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteClient(int id)
		{
			try
			{
				var data = await _repository.Delete(id);
				return Ok(data);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}



		[HttpGet("SearchByName")]
		public async Task<IActionResult> GetClientByFullName([FromBody]Client client)
		{
			try
			{
				var data = await _repository.GetClientByName(client);
				return Ok(data);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}




	}
}

