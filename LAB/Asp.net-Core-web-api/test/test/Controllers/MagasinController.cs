using System;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repository.MagasinRepository;

namespace test.Controllers
{
	[Route("api/{controller}")]
	[ApiController]
	public class MagasinController:ControllerBase
	{
		private readonly IMagasinRepository _repository;

		public MagasinController(IMagasinRepository repository) => _repository = repository;


		[HttpPost("")]
		public async Task<IActionResult> AddMagasin(Magasin magasin)
		{
			try
			{
				await _repository.Add(magasin);
				return Ok();
			}catch(Exception e)
            {
				return BadRequest();
            }
		}


		[HttpGet("")]
		public async Task<IActionResult> getAllMagasin()
		{
			try
			{
				var data=await _repository.GetAll();
				return data!=null?Ok(data):NotFound();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> getAllMagasin(int id)
		{
			try
			{
				var data = await _repository.Get(id);
				return data != null ? Ok(data) : NotFound();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}




	}
}

