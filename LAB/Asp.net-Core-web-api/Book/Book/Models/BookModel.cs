using System;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
	public class BookModel
	{
	
		public int Id { get; set; }
		[Required]
		//[Required(ErrorMessage ="")]
		//[RegularExpression]
		//[EmailAddress]
		//[MaxLength(5)]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
	
	}
}

