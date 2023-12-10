using System;
using test.DB;
using test.Models;

namespace test.Repository.MagasinRepository
{
	public class MagasinRepository:GenericRepository<Magasin> ,IMagasinRepository
	{
		private readonly DBContext _context;

		public MagasinRepository(DBContext context):base(context) => _context = context;

		
	}
}

