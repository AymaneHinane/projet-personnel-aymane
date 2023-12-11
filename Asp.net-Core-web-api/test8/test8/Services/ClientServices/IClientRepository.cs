using System;
using test8.Model.Shop;

namespace test8.Services.ClientServices
{
	public interface IClientRepository
	{
		Task<IEnumerable<Customer>> GetAll();
		Customer GetById(int id);
	}
}

