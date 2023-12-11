using System;
using Microsoft.EntityFrameworkCore;
using test2.Data;
using test2.Models;

namespace test2.Services.BookServices
{
	public class BookRepository :GenericRepository<Book>,IBookRepository
	{

		public BookRepository(ApplicationDbContext context):base(context) 
			{			  
			 
			}

        public async Task AddCategorie(string CategoryName)
        {
            await _context.Categories!.AddAsync(new Category() { Name = CategoryName });
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Book>> GetBookByAuthor(string author)
        {
            var data = await _context.Books!
                       .Where(x => x.Author!.FullName!.Contains(author))
                       .ToListAsync();

            if (data.FirstOrDefault() != null)
                return data;
            else
                throw new Exception($"no data found found");
        }

        public async Task<IEnumerable<Book>> GetBookByAuthorCategorie(string author, string categorie)
        {
            var data = await _context.Books!
                       .Where(x => x.Author!.FullName!.Contains(author) && x.Category!.Name == categorie)
                       .ToListAsync();

            if (data.FirstOrDefault() != null)
                return data;
            else
                throw new Exception($"no data found found");
        }

        public async Task<IEnumerable<Book>> GetBookByCategorie(string categorie)
        {
            var data = await _context.Books!
                       .Where(x=> x.Category!.Name == categorie)
                       .ToListAsync();

            if (data.FirstOrDefault() != null)
                return data;
            else
                throw new Exception($"no data found found");
        }

        public async Task<IEnumerable<Book>> GetBookByName(string Name)
        {
            var data = await _context.Books!
                       .Where(x => x.Name!.Contains(Name))
                       .ToListAsync();

            if (data.FirstOrDefault() != null)
                return data;
            else
                throw new Exception($"no data found found");
        }

        public async Task<IEnumerable<Book>> GetBookByNameAuthor(string Name, string author)
        {
            var data = await _context.Books!
                       .Where(x => x.Author!.FullName!.Contains(author))
                       .ToListAsync();

            if (data.FirstOrDefault() != null)
                return data;
            else
                throw new Exception($"no data found found");
        }

        public async Task<IEnumerable<Book>> GetBookByNameCategorie(string Name, string categorie)
        {
            var data = await _context.Books!
                       .Where(x => x.Name!.Contains(Name) && x.Category!.Name == categorie)
                       .ToListAsync();

            if (data.FirstOrDefault() != null)
                return data;
            else
                throw new Exception($"no data found found");
        }

        public async Task<IEnumerable<Book>> GetBookByNameCategorieAuthor(string Name, string categorie, string author)
        {
            var data = await _context.Books!
                       .Where(x => x.Author!.FullName!.Contains(author) && x.Category!.Name == categorie && x.Author.FullName.Contains(author))
                       .ToListAsync();

            if (data.FirstOrDefault() != null)
                return data;
            else
                throw new Exception($"no data found found");
        }
    }
}

