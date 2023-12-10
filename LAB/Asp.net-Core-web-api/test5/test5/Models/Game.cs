using System;
namespace test5.Models
{
	public class Game
	{
		public int Id { get; set; }
		public string Name { get; set; } = String.Empty;

		public int GameStateId { get; set; }
		public GameState GameState { get; set; }

		public List<Category> Categories { get; set; } = new();

		public List<Studiot> Studiots { get; set; } = new();

		public int EditorId { get; set; }
		public Editor Editor { get; set; }


	}
}

