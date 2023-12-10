using System;
using Microsoft.AspNetCore.Mvc;
using test3.Models;
using test3.Services.PharmacieServices;

namespace test3.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
	public class PharmacieController:ControllerBase
	{
		private readonly IPharmacieRepository _pharmacieRepository;

		public PharmacieController(IPharmacieRepository pharmacieRepository) => _pharmacieRepository = pharmacieRepository;


        [HttpGet("All")]
		public async Task<IActionResult> GetAll()
        {
			
				var data =await _pharmacieRepository.GetAll();
                return Ok(data);
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute]int id)
        {
            try { 
               var data =await _pharmacieRepository.GetById(id);
                return Ok(data);
            }
            catch(Exception err)
            {
                return NotFound(new { msg=err});
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] Pharmacie pharmacie)
        {
            //if(!ModelState.IsValid)
            //{
                var data=await _pharmacieRepository.AddItem(pharmacie);
                return Ok(data);
            //}

            //return BadRequest();
        }



	}
}

