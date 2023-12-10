using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository;

namespace Shop.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientController:ControllerBase
	{
		private readonly IClientRepository _clientRepository;

		public ClientController(IClientRepository clientRepository)
        {
			_clientRepository = clientRepository;
        }

		[HttpPost("")]
       public async Task<IActionResult> addClient([FromBody] ClientModel client)
		{
			try
			{
				await _clientRepository.AddClient(client);
				return Ok(client);
            }
            catch(Exception e)
            {
				return BadRequest(new { error_msg = e.InnerException.Message });
            }
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAllClient()
        {

			var data = await _clientRepository.GetAllClient();
			return Ok(data);
        }

	}
}

