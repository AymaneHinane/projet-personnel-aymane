using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using tp9.Library;

namespace tp9.Errors
{
	public class PlaceOrderInDto
    {

        public bool AcceptTAndCs { get; private set; }

        public int UserId { get; private set; }

        public IImmutableList<LineItem> LineItems { get; private set; } 

        public PlaceOrderInDto(bool acceptTAndCs, int userId, IImmutableList<LineItem> lineItems)
        {
            AcceptTAndCs = acceptTAndCs;
            UserId = userId;
            LineItems = lineItems;
        }

        
    }
}

