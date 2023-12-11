using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using test8.Model.Library;
using tp9.Library;

namespace tp9.Errors
{
    public interface IPlaceOrderDbAccess
	{
        //IImmutableList<ValidationResult> Errors { get; }
        //bool HasErrors { get;}

        bool FindCustomerExist(int id);
        IDictionary<int, Books> FindBooksByIdsWithPriceOffers(IEnumerable<int> bookIds);
        IDictionary<int, string> FindBookById(IEnumerable<int> bookIds);
        void Add(Orders newOrder);
    }
}

