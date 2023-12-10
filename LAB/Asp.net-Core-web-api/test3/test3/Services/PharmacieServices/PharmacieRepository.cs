using System;
using test3.DB;
using test3.Models;
using test3.Services.GenericServices;

namespace test3.Services.PharmacieServices
{
	public class PharmacieRepository:GenericRepository<Pharmacie>, IPharmacieRepository
	{
		

		public PharmacieRepository(ApplicationDbContext _context) : base(_context)
        {

        }

	}
}

