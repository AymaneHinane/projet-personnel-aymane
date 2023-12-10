using System;
using test.Models;

namespace test.Repository
{
	public interface IEmployeeRepository: IGenericRepository<Employee>
	{
		Task<Employee> GetEmployeeByName(Employee employee);
	}
}

