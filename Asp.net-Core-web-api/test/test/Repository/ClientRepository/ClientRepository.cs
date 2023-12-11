using System;
using Microsoft.EntityFrameworkCore;
using test.DB;
using test.Models;

namespace test.Repository.ClientRepository
{
	public class ClientRepository:GenericRepository<Client>,IClientRepository
	{
		//private readonly DBContext _context;

        public ClientRepository(DBContext context) : base(context) { }// => _context = context;

        public async Task<Client> GetClientByName(Client client)
        {
           
            if (_context != null)
            {
              var data = await _context.Clients
                         .Where(c => c.FirstName == client.FirstName && c.LastName == client.LastName)
                         .FirstAsync();
                return data;
            }

            return null;
        }
    }
}

