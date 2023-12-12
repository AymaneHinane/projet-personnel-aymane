using System;
using test8.DB;
using test8.Model.Library;
using tp9.DTO;

namespace tp9.Services
{
    public class ChangePubDateService : IChangePubDateService
    {
        private readonly DBContext _context;

        public ChangePubDateService(DBContext context)
        {
            _context = context;
        }

        public ChangePubDateDto GetOriginal(int id)
        {
            return _context.Books
                .Select(b => new ChangePubDateDto()
                {
                    Bookid = b.BookId,
                    Title = b.Title,
                    PublishedOn = b.PublishedOn
                })
                .Single(b => b.Bookid == id);

        }


        public Books UpdateBook(ChangePubDateDto dto)
        {
            var book = _context.Books.SingleOrDefault(x => x.BookId == dto.Bookid);

            if(book == null)
            {
                throw new ArgumentException("book not found");
            }

            book.PublishedOn = dto.PublishedOn;
            _context.SaveChanges();

            return book;
        }

    }
}

