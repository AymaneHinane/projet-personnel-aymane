using System;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repository;

namespace test.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController:ControllerBase
	{

		//private readonly IRepository<Employee> _repository;
		//public EmployeeController(IRepository<Employee> repository) => _repository = repository;

		private readonly IEmployeeRepository _repository;

		public EmployeeController(IEmployeeRepository repository) => _repository = repository;


		[HttpPost("")]
		public async Task<IActionResult> addEmployee([FromBody] Employee employee)
        {			
				var data = await _repository.Add(employee);
				return Ok(data);					
        }


		[HttpGet("{id}")]
		public async Task<IActionResult> getEmployee([FromRoute] int id)
        {
			var data = await _repository.Get(id);
			if(data == null)
            {
				return NotFound();
            }
			return Ok(data);
        }


		[HttpGet("")]
		public async Task<IActionResult> GetAllEmployees()
		{
			var data = await _repository.GetAll();

			if (data != null)
				BadRequest();

			return Ok(data);
		}

		[HttpGet("SearchByName")]
		public async Task<IActionResult> GetEmployeeByFullName([FromBody] Employee employee)
        {

			try
			{
				var data = await _repository.GetEmployeeByName(employee);
				return Ok(data);
			}catch(Exception e)
            {
               return BadRequest();
            }
			

        }


	}
}

