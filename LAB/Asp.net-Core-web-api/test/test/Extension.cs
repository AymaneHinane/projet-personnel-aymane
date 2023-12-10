using System;
using Microsoft.EntityFrameworkCore;

namespace test
{
	public static  class Extension
	{

		public static IEnumerable<T> Filter<T>(this DbSet<T> records,Func<T,bool> func)where T:class
        {
			List<T> filteredList = new List<T>();

			foreach(T record in records)
            {
				if(func(record))
                {
					filteredList.Add(record);
                }
            }

			return filteredList;
        }
	}
}

