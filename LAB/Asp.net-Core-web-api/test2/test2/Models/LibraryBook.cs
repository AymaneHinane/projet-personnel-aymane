using System;
namespace test2.Models
{
	public class LibraryBook
	{
		public int BookId { get; set; }
		public Book? Book { get; set; }

		public int LibraryId { get; set; }
		public Library? Library { get; set; }

		public int BookQuantity { get; set; }

	}
}

