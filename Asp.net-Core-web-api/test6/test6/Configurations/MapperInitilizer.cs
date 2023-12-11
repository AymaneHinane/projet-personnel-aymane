using System;
using AutoMapper;
using test6.Models;
using test6.Models.DTO;

namespace test6.Configurations
{
	public class MapperInitilizer:Profile
	{
		public MapperInitilizer()
		{
			//you will map Client to ClientDTO
			CreateMap<Client, ClientInfoDTO>()
				.ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
				.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
			.ReverseMap();


            CreateMap<CreateClientDTO, Client>()
				.ForMember(dest => dest.Address , opt => opt.MapFrom(src=>src.Address))
				.ReverseMap();

			CreateMap<UpdateClientDTO, Client>()
               //Client                           CreateClientDTO
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address)).ReverseMap();
		
             

        }
	}
}

