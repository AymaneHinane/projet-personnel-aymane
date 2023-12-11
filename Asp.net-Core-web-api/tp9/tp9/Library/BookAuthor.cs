using System;
using tp9.Library;

namespace test8.Model.Library
{
	public class BookAuthor
	{
		public int BookId { get; set; }
		public Books Book { get; set; }

        public int AuthorId { get; set; }
		public Author Author { get; set; }

	}
}

