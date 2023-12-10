using System;
using Microsoft.AspNetCore.Mvc;

namespace test2._0.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class Student:ControllerBase
	{
		private static HttpClient _httpClient;

		static Student()
		{
			_httpClient = new HttpClient();
		}


		public async Task<string> Get()
		{
			throw new Exception("not founded");

			return "hello";
				
		}
	}
}

