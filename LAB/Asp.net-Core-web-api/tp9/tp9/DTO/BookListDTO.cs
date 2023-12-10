using System;
namespace tp9.DTO
{
	public class BookListDTO
	{
		public int BookId { get; set; } 
		public string Title { get; set; } 
	    public DateTime PublishedOn { get; set; }
		public decimal? Price { get; set; } 
		public decimal ActualPrice { get; set; } 
		public string PromotionPromotionaltext { get; set; } //
		public string AuthorsOrdered { get; set; } 
		public int ReviewsCount { get; set; }//
		public double? ReviewsAverageVotes { get; set; } 
		public string[] TagStrings { get; set; } //
	}
}

