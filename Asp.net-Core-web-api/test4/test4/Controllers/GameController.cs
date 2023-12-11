using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using test4.Data;
using test4.Model;

namespace test4.Controllers
{

	[ApiController]
    [Route("api/[controller]")]
	public class GameController:ControllerBase
	{
		private readonly ApplicationDbContext context;

		public GameController(ApplicationDbContext context)
		{
			this.context = context;
		}

        [HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Game))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById(int id)
        {
			var data = context.Games.FirstOrDefaultAsync(x => x.ID == id);
			if (data != null)
				return Ok();
			return NotFound();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created,Type=typeof(Game))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddGame([FromBody] Game game)
        {
			try
			{
				context.Add(game);
				await context.SaveChangesAsync();

				//return Created("Game", game);
				//return CreatedAtAction(nameof(GetById), new { id= game.ID },game);
				return StatusCode((int)HttpStatusCode.Created);
				//throw new ArgumentException("Invalid data ", nameof(game));			

			}catch(Exception ex)
            {
				return BadRequest(ex.Message);
            }
        }

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Game>))]
		public async Task<IActionResult> GetAllGame()
		{
			var data = await context.Games.ToListAsync();
			
			return Ok(data);
		}


		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> DeleteGenre([FromRoute] int id)
		{
			try
			{
				var genre = context.GameGenres.FirstOrDefault(x => x.ID == id);
				if (genre != null)
				{
					context.Remove(genre);
					await context.SaveChangesAsync();					
				}
			}catch(ArgumentException)
            {
               return NotFound();
            }

			return NoContent();

			//catch (SqlException err)
			//{
			//	return BadRequest(err.Message);
			//}
		}



	}
}

