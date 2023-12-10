using System;
using System.ComponentModel.DataAnnotations;

namespace tp9.DTO
{

	/// [AutoMap(typeof(Book))]

	public class ChangePubDateDto
	{
		public int Bookid { get; set; }
		public string Title { get; set; }

		[DataType(DataType.Date)]
		public DateTime PublishedOn { get; set; }
	}
}

