using System;
using System.ComponentModel.DataAnnotations;

namespace tp9.Library
{
	public class ConcurrencyAuthor
	{
		public int ConcurrencyAuthorId { get; set; }
		public string Name { get; set; }
		[Timestamp]
		public byte[] ChangeCheck { get; set; }



    }
}

