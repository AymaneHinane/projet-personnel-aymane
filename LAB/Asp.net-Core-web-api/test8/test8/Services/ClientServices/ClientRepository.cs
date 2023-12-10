using System;
using Microsoft.EntityFrameworkCore;
using test8.DB;
using test8.Model.Shop;

namespace test8.Services.ClientServices
{
	public class ClientRepository: IClientRepository
    {
        private readonly DBContext _context;

		public ClientRepository(DBContext context)
		{
            _context = context ?? throw new ArgumentNullException(nameof(DBContext));
		}

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var data = await _context.Customers
                //.Select(
                //x => new {
                //    Id=x.Id,
                //    Name=string.Concat(x.FirstName,' ',x.LastName)
                //})
                .ToListAsync();

            return data;
        }

        public Customer GetById(int id)
        {
            var data =_context.Customers.Single(x => x.Id == id);

            return data;
        }
    }
}

