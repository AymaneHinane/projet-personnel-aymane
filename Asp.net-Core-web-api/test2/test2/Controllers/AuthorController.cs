using System;
using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.Services.AuthorServices;

namespace test2.Controllers
{
	[ApiController]
	[Route("api/{controller}")]
	public class AuthorController:ControllerBase
	{
		private readonly IAuthorRepository _authorRepository;

		public AuthorController(IAuthorRepository authorRepository) => _authorRepository = authorRepository;


		[HttpGet]
		public async Task<IActionResult> GetAllAuthors()
        {
			try
			{
				var data = await _authorRepository.GetAll();
				return Ok(data);
			}catch(Exception e)
            {
				return NotFound(new { msg = e.Message});
			}

        }

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAuthor([FromRoute]int id)
        {
            try
            {
				var data = await _authorRepository.GetById(id);
				return Ok(data);
            }
            catch (Exception e)
            {
				return NotFound(new { msg = e.Message });
			}
        }


		[HttpPost]
		public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
			try
			{
				if (ModelState.IsValid)
				{
					await _authorRepository.add(author);
					return Ok();
				}
				else
					throw new Exception();
			}catch(Exception e)
            {
				return BadRequest(e.Message);
            }		    
        }


		[HttpPost("{id}/AddBook/{category}")]
		public async Task<IActionResult> AddBook([FromRoute]int id,[FromBody]Book book,[FromRoute]string category)
        {
			
			await _authorRepository.AddBook(id, book,category);
			return Ok();
        }


	}
}

