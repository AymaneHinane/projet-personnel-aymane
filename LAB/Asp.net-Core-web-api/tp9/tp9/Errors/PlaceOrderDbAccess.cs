using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using test8.DB;
using test8.Model.Library;
using tp9.Library;

namespace tp9.Errors
{
	public class PlaceOrderDbAccess:IPlaceOrderDbAccess
    {

        private readonly DBContext _context;

        public PlaceOrderDbAccess(DBContext context)
		{
            _context = context;
		}

        //public IImmutableList<ValidationResult> Errors => this.Errors;
        //public bool HasErrors => this.HasErrors;

        public bool FindCustomerExist(int id)
        {
            bool IsExist = _context.Customers.Any(x => x.CustomerId == id);

            return IsExist;

        }


        public void Test()
        {
            foreach(var entry in _context.ChangeTracker.Entries())
            {
                if(entry.State == EntityState.Added || entry.State == EntityState.Modified)
                { }

            }

            foreach (var entry in _context.ChangeTracker.Entries().Where(entry=>
               entry.State == EntityState.Added || entry.State == EntityState.Modified
            ))
            {
                

            }
        }

        public IDictionary<int, Books> FindBooksByIdsWithPriceOffers(IEnumerable<int> bookIds)
        {
            var book = _context.Books
                .Include(b => b.Promotion)
                .Where(b => bookIds.Contains(b.BookId))
                .ToDictionary(b => b.BookId);

            return book;
        }
      
        public IDictionary<int,string> FindBookById(IEnumerable<int> bookIds)
        {
            var book = _context.Books.Where(b => bookIds.Contains(b.BookId)).ToDictionary(b=>b.BookId,b=>b.Title);

            return book;
        }

        public void Add(Orders newOrder)                 
        {                                               
            _context.Orders.Add(newOrder);              
        } 
    }
}

