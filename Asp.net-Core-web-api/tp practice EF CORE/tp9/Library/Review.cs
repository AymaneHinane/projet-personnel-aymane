using System;
namespace test8.Model.Library
{
	public class Review
	{
       public int ReviewId { get; set; }
       public string VoterName { get; set; }
       public double NumStars { get; set; }
       public string Comment { get; set; }

       public int BookId { get; set; }
       public Books Book { get; set; }
    }
}

