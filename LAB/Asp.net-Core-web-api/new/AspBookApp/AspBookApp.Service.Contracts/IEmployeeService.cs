

using AspBookApp.Shared;

namespace AspBookApp.Service.Contracts;

public interface IEmployeeService{

    Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId, bool trackChanges,EmployeeParameters employeeParameters);
    Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

    Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation
                                                     ,bool trackChanges);

    Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);

    Task UpdateEmployeeForCompanyAsync( Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate,
                                        bool compTrackChanges, bool empTrackChanges);

}