using System;
using Shop.Models;

namespace Shop.Repository
{
	public interface IClientRepository
	{
		Task<ClientModel> AddClient(ClientModel clientModel);
		Task<List<ClientModel>> GetAllClient();
		//Task<IEnumerable<ClientModel>> GetAllClient();

	}
}

