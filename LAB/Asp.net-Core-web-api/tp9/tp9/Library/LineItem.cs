using System;
using System.ComponentModel.DataAnnotations;
using test8.Model.Library;

namespace tp9.Library
{
	public class LineItem: IValidatableObject
    {

       // [Range(1, 5, ErrorMessage =
       //"This order is over the limit of 5 books.")]
        //public int LineItemId { get; set; }
        public int Quatity { get; set; }

		public decimal Price { get; set; }


		public int BookId { get; set; }
		public Books? Book { get; set; }

		public int OrderId { get; set; }
		public Orders? Order { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
			if (Quatity > 100)
				yield return new ValidationResult("If you want to order quantity over 100 please contact ");
        }
    }
}

