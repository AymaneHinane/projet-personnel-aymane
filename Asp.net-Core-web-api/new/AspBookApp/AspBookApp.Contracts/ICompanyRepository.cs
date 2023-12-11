
using AspBookApp.Entities.Models;

namespace AspBookApp.Contracts.Repository;


public interface ICompanyRepository
{
   Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
   Task<Company?> GetCompanyAsync(Guid companyId, bool trackChanges);
   void CreateCompany(Company company);
   Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
   void DeleteCompany(Company company);

   Task<Company?> GetCompanyWithEmployeeAsync(Guid companyId, bool trackChanges);
}

