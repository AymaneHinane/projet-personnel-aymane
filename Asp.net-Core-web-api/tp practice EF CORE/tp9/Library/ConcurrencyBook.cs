using System;
using System.ComponentModel.DataAnnotations;

namespace tp9.Library
{
	public class ConcurrencyBook
	{
		public int ConcurrencyBookId { get; set; }
		public string Title { get; set; }

		[ConcurrencyCheck]
		public DateTime PublishOn { get; set; }

		//public ConcurrencyAuthor Author { get; set; }
    }
}

