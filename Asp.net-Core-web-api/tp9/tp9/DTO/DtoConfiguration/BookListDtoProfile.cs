using System;
using AutoMapper;
using test8.Model.Library;

namespace tp9.DTO.DtoConfiguration
{
	public class BookListDtoProfile:Profile
	{
		public BookListDtoProfile()
		{
			CreateMap<Books, BookListDTO>()
				.ForMember(p => p.ActualPrice,
							m => m.MapFrom(s => s.Promotion == null ? s.Price : s.Promotion.NewPrice)
						)
				.ForMember(p => p.AuthorsOrdered,
							m => m.MapFrom(s => string.Join(", ", s.BookAuthors.Select(x => x.Author.Name)))
						)
				.ForMember(p => p.ReviewsAverageVotes,
							m => m.MapFrom(s => s.Reviews.Select(y => (double?)y.NumStars).Average())
						);
		}
	}
}

