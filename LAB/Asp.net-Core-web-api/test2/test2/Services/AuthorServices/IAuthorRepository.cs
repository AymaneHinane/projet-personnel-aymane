using System;
using test2.Models;

namespace test2.Services.AuthorServices
{
	public interface IAuthorRepository: IGenericRepository<Author>
	{
		Task RemoveAuthorRange(IEnumerable<int> id);
		Task AddBook(int id,Book book,string category);
	}
}

