using System;
using System.ComponentModel.DataAnnotations;

namespace test8.Model.Library
{
	public class Author
	{       
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string WebUrl { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}

