using System;
using System.Text.Json.Serialization;

namespace test5.Models
{
	public class Editor
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public List<Studiot> Studiots { get; set; } = new();

		public List<Game> Games { get; set; } = new();

		[JsonIgnore]
		public List<Employee> Employees { get; set; } = new();
	}
}

