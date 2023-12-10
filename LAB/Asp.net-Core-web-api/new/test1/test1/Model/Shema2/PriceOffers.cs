using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace test1.Model.Shema2
{
	public class PriceOffers
	{
		public int PriceOffersId;
		public decimal NewPrice;

        public int BookId;
        public Book Book;


    }


    public class PriceOffersEntityTypeConfiguration : IEntityTypeConfiguration<PriceOffers>
    {
        public void Configure(EntityTypeBuilder<PriceOffers> builder)
        {
            builder.HasKey(p => p.PriceOffersId);
        }
    }
}

