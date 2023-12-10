using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using tp9.Library;

namespace test8.Model.Library
{
    public class Books
    {
        
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool SoftDeleted { get; set; }

        public decimal Price { get; set; }

        public PriceOffers? Promotion { get; set; }

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Tags>? Tags { get; set; }

        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public ICollection<LineItem>? lineItems { get; set; }




    }

}

