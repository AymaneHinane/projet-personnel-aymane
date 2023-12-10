using System;
using test8.Model.Library;

namespace tp9.Services
{
	public interface IChangePriceOfferService
	{
        PriceOffers GetOriginal(int id);

        Books AddUpdatePriceOffer(PriceOffers promotion);

        Books AddRemovePriceOffer(PriceOffers promotion);
    }
}

