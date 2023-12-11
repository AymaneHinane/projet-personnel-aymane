using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.DB;
using Shop.Models;

namespace Shop.Repository
{
	public class ClientRepository: IClientRepository
	{
		private readonly DBContext _dBContext;
		private readonly IMapper _mapper;

		public ClientRepository(DBContext dBContext,IMapper mapper)
		{
			_dBContext = dBContext;
			_mapper = mapper;
		}

		public async Task<ClientModel> AddClient(ClientModel Client)
		{
		     	 var client = _mapper.Map<ClientModel>(Client);
				await _dBContext.client.AddAsync(client);
				await _dBContext.SaveChangesAsync();
				return client;


		}

		public async Task<List<ClientModel>> GetAllClient()
		{
			//var data = await _dBContext.client.ToListAsync();
			var data = await _dBContext.client.Include(c=>c.AddressModel).ToListAsync();


			//var client= _mapper.Map<List<ClientModel>>(data);

			return data;
        }

	}
}

