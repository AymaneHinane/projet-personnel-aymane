using System;
using Microsoft.EntityFrameworkCore;
using test8.Model.Library;
using tp9.DTO;

namespace tp9.ExtensionMethod
{
	public enum OrderByOptions
	{
        SimpleOrder,
        ByVotes,
        ByPublicationDate,
        ByPriceLowestFirst,
        ByPriceHighestFirst
    }

	public enum BooksFilterBy
	{
        NoFilter,
        ByVotes,
        ByTags,
        ByPublicationYear
    }

    // Query Object pattern
    public static class BookExtensionMethod
	{
		public static IQueryable<BookListDTO> MapBookToDto(this IQueryable<Books> books)
		{
			
			return books.Select(book => new BookListDTO
			{
				
				BookId = book.BookId,
				Title = book.Title,
				PublishedOn = book.PublishedOn,
				Price = book.Promotion == null ? book.Price : book.Promotion.NewPrice,
				PromotionPromotionaltext = book.Promotion == null ? null : book!.Promotion.PromotionalText,
				AuthorsOrdered = String.Join(',',book.BookAuthors
								 .OrderBy(b=>b.Author.Name)
								 .Select(b=>b.Author.Name)
								 ),
				ReviewsCount = book.Reviews.Count,
				ReviewsAverageVotes = book.Reviews.Average(b=>b.NumStars),
				TagStrings = book.Tags.Select(t=>t.TagsId).ToArray()
			}) ;
		}

		public static IQueryable<BookListDTO> OrderBooksBy(this IQueryable<BookListDTO> books, OrderByOptions orderByOptions)
		{
			switch(orderByOptions)
			{
				case OrderByOptions.SimpleOrder:
					return books.OrderBy(x => x.BookId);
				case OrderByOptions.ByVotes:
					return books.OrderBy(x => x.ReviewsAverageVotes);
				case OrderByOptions.ByPublicationDate:
					return books.OrderBy(x => x.PublishedOn);
                case OrderByOptions.ByPriceLowestFirst:
                    return books.OrderBy(x => x.ActualPrice);
                case OrderByOptions.ByPriceHighestFirst:
                    return books.OrderByDescending(
                        x => x.ActualPrice);
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOptions), orderByOptions, null);
            }
		}


		public static IQueryable<BookListDTO> FilterBookBy(this IQueryable<BookListDTO>books, BooksFilterBy filterBy,string FilterValue)
		{
			if (string.IsNullOrEmpty(FilterValue))
				return books;

			switch(filterBy)
			{
				case BooksFilterBy.NoFilter:
					return books;
				case BooksFilterBy.ByVotes:
					var filterVote = int.Parse(FilterValue);
					return books.Where(x => x.ReviewsAverageVotes >= filterVote);
				case BooksFilterBy.ByTags:
					return books.Where(x => x.TagStrings.Any(y=>y == FilterValue));

				case BooksFilterBy.ByPublicationYear:
					var filterYear = DateTime.Parse(FilterValue);
					return books.Where(x => x.PublishedOn >= filterYear && x.PublishedOn > DateTime.UtcNow);

				default:
					throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);

			}
		}


		public static IQueryable<BookListDTO> Page(this IQueryable<BookListDTO>books, int pageNumZeroStart, int pageSize)
		{
			if (pageSize == 0)
				throw new ArgumentOutOfRangeException(nameof(pageSize),pageSize,null);

			if (pageNumZeroStart != 0)
				books = books.Skip(pageNumZeroStart * pageSize);

			return books.Take(pageSize);

		}





    }
}

