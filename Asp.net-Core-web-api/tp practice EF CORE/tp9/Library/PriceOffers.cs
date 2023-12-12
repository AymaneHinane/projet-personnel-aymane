using System;
namespace test8.Model.Library
{
	public class PriceOffers
	{
        public int PriceOffersId { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotionalText { get; set; }

        public int BookId { get; set; }
        public Books? Book { get; set; }
    }
}

