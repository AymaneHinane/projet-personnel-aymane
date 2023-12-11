using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace test4.Model
{
	public class GameGenre
	{
		public int ID { get; set; }

		[MaxLength(150)]
        [Required]
		public string Name { get; set; } = string.Empty;

        [JsonIgnore]
		public List<Game>? Games { get; set; }
	}
}

