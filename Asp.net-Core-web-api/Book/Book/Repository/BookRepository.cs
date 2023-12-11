using System;
using Book.Data;
using Book.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Book.Repository
{
	public class BookRepository:IBookRepository
	{
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
		{
            _context = context;
        }



		public async Task<List<BookModel>> GetAllBookAsync()
		{
			var records = await _context.Book.ToListAsync();/*Select(x=>new BookModel()
            {
				Id=x.Id,
				Title=x.Title,
				Description=x.Description
            }).ToListAsync();*/

			return records;
		}

		public async Task<BookModel> GetBookByIdAsync(int bookId)
		{
			//var records = await _context.Book.Where(x => x.Id == bookId).FirstOrDefaultAsync();
			var records = await _context.Book.FindAsync(bookId);

			return records;
		}

		public async Task<int> AddBookAsync(BookModel bookModel)
		{
			/*var book = new BookModel()
			{
				Title=bookModel.Title,
				Description=bookModel.Description
			};*/

			_context.Book.Add(bookModel);
			await _context.SaveChangesAsync();

			return bookModel.Id;

        }

		public async Task UpdateBookAsync(int bookId,BookModel bookModel)
		{
			//var book = await _context.Book.FindAsync(bookId);

			//if(book != null)
			//{
			//	book.Title = bookModel.Title;
			//	book.Description = bookModel.Description;

			//	await _context.SaveChangesAsync();
			//}

			//var book = new BookModel()
			//{
			//	Id=bookId,
			//	Title = bookModel.Title,
			//	Description = bookModel.Description
			//}; 

			  bookModel.Id = bookId;
			 _context.Book.Update(bookModel);
			await _context.SaveChangesAsync();

		}


		public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
			var book = await _context.Book.FindAsync(bookId);

			if (book != null)
            {
                bookModel.ApplyTo(book);
				await _context.SaveChangesAsync();
            }

        }


		public async Task DeleteBookAsync(int bookId)
		{
			//var book = await _context.Book.FindAsync(bookId);

			//if (book != null)
			//{
			    var book = new BookModel() { Id = bookId };
				_context.Book.Remove(book);
				await _context.SaveChangesAsync();
			//}

		}


	}
}

