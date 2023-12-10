using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace test4.Model
	{
		public class Game
		{	
		    public int ID { get; set; }

		    [MaxLength(150)]
		    [Required]
	        public string Name { get; set; } = string.Empty;

		    public GameGenre? Genre { get; set; }
		    public int GenreId { get; set; }

		    public int PersonnalRanting { get; set; }		    
		}
	}

