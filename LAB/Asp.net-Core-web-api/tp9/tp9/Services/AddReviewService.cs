using System;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using test8.DB;
using test8.Model.Library;

namespace tp9.Services
{
	public class AddReviewService
	{

		private readonly DBContext _context;

		public AddReviewService(DBContext context)
		{
			_context = context;
		}

		public Review? GetBlankReview(int id)
		{
            //var book = _context.Books.Where(b => b.BookId == id)
            //	.Select(b => b.BookId)
            //	.Single();
            //var BookExiste = _context.Books.Any(b => b.BookId == id);

            //return BookExiste ? new Review { BookId = id }:null;

            var BookTitle = _context.Books
                            .Where(p => p.BookId == id)
                            .Select(p => p.Title)
                            .Single();
        
            return new Review
                    {
                      BookId = id
                    };
        }

        public Books AddReviewToBook(Review review)
		{
            var book = _context.Books
                       .Include(r => r.Reviews)
                       .Single(k => k.BookId == review.BookId);

            book.Reviews.Add(review);
            _context.SaveChanges();

            return book;
        }

    }
}

