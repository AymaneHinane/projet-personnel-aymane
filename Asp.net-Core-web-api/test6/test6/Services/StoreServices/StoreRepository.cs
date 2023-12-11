using System;
using test6.DB;
using test6.Models;
using test6.Repository.GenericRepository;

namespace test6.Repository.StoreRepository
{
	public class StoreRepository:GenericRepository<Store>,IStoreRepository
	{
		public StoreRepository(DBContext context) : base(context)
		{
		}
	}
}

