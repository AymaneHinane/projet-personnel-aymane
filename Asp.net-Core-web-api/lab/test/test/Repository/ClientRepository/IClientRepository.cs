using System;
using test.Models;

namespace test.Repository.ClientRepository
{
	public interface IClientRepository:IGenericRepository<Client>
	{
		Task<Client> GetClientByName(Client client);
	}
}

