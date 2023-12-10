using System;
using test8.Model;

namespace test8.Services.BlogAuthorServices
{
	public interface IBlogRepository
	{

		Task AddBlog();
		Task<List<Blog>> GetBlogs();
		Task<List<Author>> GetAuthors();

        public Task SaveChange();
	}
}

