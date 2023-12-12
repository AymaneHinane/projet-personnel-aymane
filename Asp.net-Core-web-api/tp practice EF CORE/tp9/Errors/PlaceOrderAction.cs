using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using test8.Model.Library;
using tp9.Library;

namespace tp9.Errors
{
	public class PlaceOrderAction: IBizAction<PlaceOrderInDto,Orders>
    {
        private readonly IPlaceOrderDbAccess _dbAccess;
        private readonly IBizActionErrors _bizActionErrors;


        public PlaceOrderAction(IPlaceOrderDbAccess dbAccess, IBizActionErrors bizActionErrors)
        {
            _dbAccess = dbAccess;
            _bizActionErrors = bizActionErrors;
		}

        //si cette class serat acceder via une interface tous le propriete et methode necessaire doivent etre declarer
        //dans l'interface et implementer dans la class

        //public IImmutableList<ValidationResult> Errors => this.Errors;
        //public bool HasErrors => this.HasErrors;


        



        public Orders Action(PlaceOrderInDto dto)
        {

            if (this._dbAccess.FindCustomerExist(dto.UserId) == false)
            {
                _bizActionErrors.AddError($"the Users with Id {dto.UserId} are not exist",nameof(dto.UserId));
            }

           if(dto.AcceptTAndCs == false)
            {
                _bizActionErrors.AddError("You must accept the T&Cs to place an order.", nameof(dto.AcceptTAndCs));
            }

            if (!dto.LineItems.Any())
            {
                _bizActionErrors.AddError("the line Item are Empty");
            }

            var booksExists = _dbAccess.FindBookById(dto.LineItems.Select(li => li.BookId)); 

            if(booksExists is null)
            {
                _bizActionErrors.AddError("all books are not available in database");
            }           
            
            foreach(var book in dto.LineItems)
            {
                if (!booksExists.ContainsKey(book.BookId))
                    _bizActionErrors.AddError($"the book with id {book.BookId} are not exists",nameof(book.BookId));
            }

              if (_bizActionErrors.HasErrors == true)
                return null;

            var booksDict = _dbAccess.FindBooksByIdsWithPriceOffers(dto.LineItems.Select(li => li.BookId));

            var order = new Orders()
            {
                CustomerId = dto.UserId,
                DateOrderedUtc = DateTime.UtcNow,
                lineItems = FormLineItemsWithErrorChecking(dto.LineItems, booksDict)
            };

            if (!_bizActionErrors.HasErrors)
                _dbAccess.Add(order);

            return _bizActionErrors.HasErrors ? null : order;
        }

        private ICollection<LineItem> FormLineItemsWithErrorChecking(IImmutableList<LineItem> lineItems, IDictionary<int, Books> booksDict)
        {
            var result = new List<LineItem>();
           

            foreach (var lineItem in lineItems)
            {
                if(!booksDict.ContainsKey(lineItem.BookId))
                {
                    throw new InvalidOperationException("An order failed because book, " +
                          $"id = {lineItem.BookId} was missing.");
                }

                var book = booksDict[lineItem.BookId];
                var bookPrice = book.Promotion?.NewPrice ?? book.Price;

                if (bookPrice <= 0)
                    _bizActionErrors.AddError($"the book {book.BookId} is not for sale");
                else
                    result.Add(new LineItem
                    {
                        BookId = book.BookId,
                        Price = bookPrice,//(decimal) bookPrice
                        Quatity=lineItem.Quatity
                    });
            }

            return result;

        }
    }
}

