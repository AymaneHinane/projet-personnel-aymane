using System;
using test2.Models;

namespace test2.Services.BookServices
{
	public interface IBookRepository:IGenericRepository<Book>
	{
		public Task AddCategorie(string CategoryName);
		public Task<IEnumerable<Book>> GetBookByName(string Name);
		public Task<IEnumerable<Book>> GetBookByCategorie(string Categorie);
		public Task<IEnumerable<Book>> GetBookByAuthor(string author);
		public Task<IEnumerable<Book>> GetBookByNameCategorie(string Name,string categorie);
		public Task<IEnumerable<Book>> GetBookByNameAuthor(string Name, string author);
		public Task<IEnumerable<Book>> GetBookByAuthorCategorie(string author, string categorie);
		public Task<IEnumerable<Book>> GetBookByNameCategorieAuthor(string Name, string categorie,string author);
	}
}

