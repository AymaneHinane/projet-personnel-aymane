using System;
using Microsoft.EntityFrameworkCore;
using test2.Data;
using test2.Models;

namespace test2.Services.AuthorServices
{
	public class AuthorRepository: GenericRepository<Author>, IAuthorRepository
	{

		public AuthorRepository(ApplicationDbContext context):base(context)
        {

        }

        public async Task AddBook(int id,Book book,string category)
        {
            //var author=await _context.Authors!.Where(x => x.Id == id).Include(x => x.Books).FirstAsync();
            //author.Books!.Add(book);

            var categoryId = await _context.Categories!
                .Where(x => x.Name == category)
                .Select(x => new {Id=x.Id })
                .FirstOrDefaultAsync();

            if (categoryId != null)
            {
                book.CategoryId = categoryId.Id;
                book.AuthorId = id;
                await _context.Books!.AddAsync(book);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task RemoveAuthorRange(IEnumerable<int> id)
        {
            try
            {
                List<Author> authors = new List<Author>();

                foreach (var index in id)
                {
                    authors.Add(new Author { Id = index });
                }

                _context.Authors!.RemoveRange(authors);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

