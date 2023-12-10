using System;
using Microsoft.EntityFrameworkCore;
using test.DB;
using test.Models;

namespace test.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        private readonly DBContext _context;
        public EmployeeRepository(DBContext context):base(context) => _context = context;


        public async Task<Employee> GetEmployeeByName(Employee employee)
        {
            if(_context != null)
            {
            var data =await _context.Employees
                    .Where(e=> e.FirstName== employee.FirstName && e.LastName== employee.LastName).FirstAsync();             
            return data;                     
            }

            return null;

        }
    }
}

