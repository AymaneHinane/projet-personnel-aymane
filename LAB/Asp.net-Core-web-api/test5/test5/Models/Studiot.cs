using System;
namespace test5.Models
{
	public class Studiot
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public int EditorId { get; set; }
		public Editor Editor { get; set; }

		public List<Game> Games { get; set; } = new();

		public List<Employee> Employees { get; set; } = new();
	}
}

