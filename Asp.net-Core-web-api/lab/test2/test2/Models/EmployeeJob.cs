using System;
namespace test2.Models
{
	public class EmployeeJob
	{
		public int Id { get; set; }
		public string? JobName { get; set; }

		public List<Employee>? Employees { get; set; }
	}
}

