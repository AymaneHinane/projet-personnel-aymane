using System;
namespace test5.Models
{

		public enum GameCategoryEnum
        {
			RPG,
			MMO,
			MOBA,
			FPS,
			ACTION,
			ADVENTURE,
			FIGHTER,
			SPORT,
        }

	public class Category
	{
		public int Id { get; set; }
		public GameCategoryEnum GameCategory { get; set; }
		public List<Game> Games { get; set; } = new();
	}
}

