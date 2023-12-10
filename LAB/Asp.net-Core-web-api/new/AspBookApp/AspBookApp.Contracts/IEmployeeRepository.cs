
using AspBookApp.Entities.Models;
using AspBookApp.Shared;

namespace AspBookApp.Contracts.Repository;

 public interface IEmployeeRepository
{
     Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges,EmployeeParameters employeeParameters);
     Task<Employee?> GetEmployeeAsync(Guid companyId,Guid id,bool trackChanges);
     void CreateEmployeeForCompany(Guid companyId, Employee employee);

     void DeleteEmployee(Employee employee);

}
