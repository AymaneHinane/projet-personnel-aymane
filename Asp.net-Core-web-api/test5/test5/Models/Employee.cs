using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace test5.Models
{
	
	public enum Job
    {
		[EnumMember(Value = "GAMEDESIGNER")]
		GAMEDESIGNER,
		[EnumMember(Value = "DEVELOPER")]
		DEVELOPER,
		[EnumMember(Value = "SENIORMENTOR")]
		SENIORMENTOR,
		[EnumMember(Value = "PRODUCTOR")]
		PRODUCTOR
    }

	public class Employee
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;

		public decimal Salary { get; set; }

        [JsonIgnore]
		public int Editorid { get; set; }
		public Editor Editor { get; set; }

		public int StudiotId { get; set; }
		public Studiot Studiot { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Job job { get; set; }
	}
}

