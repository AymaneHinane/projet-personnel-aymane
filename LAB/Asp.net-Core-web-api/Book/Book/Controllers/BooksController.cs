using System;
using Book.Models;
using Book.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController:ControllerBase
	{
		private readonly IBookRepository _bookRepository;

		public BooksController(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAllBooks()
		{
			var books = await _bookRepository.GetAllBookAsync();
			return Ok(books);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBookById([FromRoute] int id)
		{
			var books = await _bookRepository.GetBookByIdAsync(id);

			if (books == null)
				return NotFound();

			return Ok(books);
		}

		[HttpPost("")]
		public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
			Console.WriteLine($"{bookModel.Title} {bookModel.Description}");
			
			var id = await _bookRepository.AddBookAsync(bookModel);
            //return Ok(id);

			return CreatedAtAction("GetBookById", new { id = id}, bookModel);
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBook([FromRoute]int id,[FromBody] BookModel bookModel)
		{
			await _bookRepository.UpdateBookAsync(id, bookModel);
			return Ok();

		}

/*
	[
	   {
	    "op":"replace",
	    "path": "description",
	    "value":"zzzzz"
	    }
	]
*/

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateBookPatch([FromRoute] int id, [FromBody] JsonPatchDocument bookModel)
		{
			Console.WriteLine("hello 1 \n");
			await _bookRepository.UpdateBookPatchAsync(id, bookModel);
			return Ok();

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBook([FromRoute] int id)
		{
			await _bookRepository.DeleteBookAsync(id);
			return Ok();

		}




	}
}

