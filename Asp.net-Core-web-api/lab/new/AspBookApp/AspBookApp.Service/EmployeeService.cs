

using AspBookApp.Contracts.LoggerManager;
using AspBookApp.Contracts.Repository;
using AspBookApp.Entities.Exceptions;
using AspBookApp.Entities.Models;
using AspBookApp.Service.Contracts;
using AspBookApp.Shared;
using AutoMapper;

namespace AspBookApp.Service;

internal sealed class EmployeeService : IEmployeeService {

    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    private readonly IMapper _mapper;
    public EmployeeService(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
    {
       _repository = repository;
       _logger = logger;
       _mapper = mapper;
    }


    public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
    {
        var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges); 
        
        if (company is null)
              throw new CompanyNotFoundException(companyId);

       var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

       _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
       await  _repository.SaveAsync();

       var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

       return employeeToReturn;
    }

    public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
    {
       var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
        
       if (company is null)
            throw new CompanyNotFoundException(companyId);

       var employeeForCompany = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges);

       if (employeeForCompany is null)
            throw new EmployeeNotFoundException(id);

       _repository.Employee.DeleteEmployee(employeeForCompany);
       await _repository.SaveAsync();
    }

    public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
    {
       var company = await _repository.Company.GetCompanyAsync(companyId,trackChanges);

       if(company is null)
         throw new CompanyNotFoundException(companyId);

       var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId,id,trackChanges);
       
       if(employeeDb is null)
          throw new EmployeeNotFoundException(id);

       var employee = _mapper.Map<EmployeeDto>(employeeDb);

       return employee;
    }

    public async Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId, bool trackChanges,EmployeeParameters employeeParameters)
    {

      if (!employeeParameters.ValidAgeRange)
            throw new MaxAgeRangeBadRequestException();

       var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges); 

       if (company is null)
              throw new CompanyNotFoundException(companyId);

      //  var employeesFromDb = await _repository.Employee.GetEmployeesAsync(companyId,trackChanges,employeeParameters);

      //  var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

      var employeesWithMetaData = await _repository.Employee
              .GetEmployeesAsync(companyId, trackChanges,employeeParameters);
       var employeesDto =_mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

       return (employees: employeesDto, metaData: employeesWithMetaData.MetaData);
    }

    public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
    {        
       var company = await _repository.Company.GetCompanyAsync(companyId, compTrackChanges);
       
       if (company is null)
           throw new CompanyNotFoundException(companyId);

       var employeeEntity = await _repository.Employee.GetEmployeeAsync(companyId, id,empTrackChanges);

       if (employeeEntity is null)
          throw new EmployeeNotFoundException(id);

       _mapper.Map(employeeForUpdate, employeeEntity);
       
       await _repository.SaveAsync();
    }
} 

