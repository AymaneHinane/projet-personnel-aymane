using System;
namespace test5.Models
{
	public class GameState
	{
		public int Id { get; set; }

		public int GameId { get; set; }
		public Game Game { get; set; }

		public DateTime? ProjectStartDate { get; set; }
		public DateTime? AnnoucementDate { get; set; }
		public DateTime? ReleaseDate { get; set; }

		public bool InProduction { get; set; }
	}
}

