using System;
using AutoMapper;
using Shop.Models;

namespace Shop.Helpers
{
	public class ApplicationMapper:Profile
	{
		public ApplicationMapper()
		{
			CreateMap<ClientModel, ClientModel>().ReverseMap();
			
		}
	}
}

