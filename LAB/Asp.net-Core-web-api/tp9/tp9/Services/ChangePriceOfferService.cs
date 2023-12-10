using System;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using test8.DB;
using test8.Model.Library;

namespace tp9.Services
{
	public class ChangePriceOfferService : IChangePriceOfferService
    {
        private readonly DBContext _context;

        public ChangePriceOfferService(DBContext context)
		{
            _context = context;
		}


        public PriceOffers GetOriginal(int id)
        {
            var book = _context.Books.Include(b => b.Promotion)//.First(b=>b.BookId==1);
               .SingleOrDefault(b => b.BookId == id);

            if (book is null)
                throw new ArgumentNullException("book not found");

            return book.Promotion ?? new PriceOffers { BookId=id};
                

        }

        public Books AddUpdatePriceOffer(PriceOffers promotion)
        {
            var book = _context.Books
                .Include(b=>b.Promotion)
                .SingleOrDefault(b => b.BookId == promotion.BookId);

            if(book is null)
                throw new ArgumentNullException("book not found");

            if (book.Promotion is null)
                book.Promotion = promotion;
            else
            {
                book.Promotion.NewPrice = promotion.NewPrice;
                book.Promotion.PromotionalText = promotion.PromotionalText;
            }

            _context.SaveChanges();
            return book;
        }


        public Books AddRemovePriceOffer(PriceOffers promotion)
        {
            var book = _context.Books.Include(b => b.Promotion).Single();

            if(book == null)
            {
                book.Promotion = promotion;
            }
            else
            {
                _context.Remove(book.Promotion);
            }

            _context.SaveChanges();

            return book;
        }


    }
}

