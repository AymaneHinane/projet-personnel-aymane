
using AspBookApp.Contracts.LoggerManager;
using AspBookApp.Contracts.Repository;
using AspBookApp.Service.Contracts;
using AutoMapper;

namespace AspBookApp.Service;

public sealed class ServiceManager : IServiceManager
{

   public Lazy<ICompanyService> _companyService;
   public Lazy<IEmployeeService> _employeeService;

   public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger ,IMapper mapper){
       _companyService = new Lazy<ICompanyService>(new CompanyService(repositoryManager,logger,mapper));
       _employeeService = new Lazy<IEmployeeService>(new EmployeeService(repositoryManager,logger,mapper));
   }

    public ICompanyService CompanyService => _companyService.Value;

    public IEmployeeService EmployeeService => _employeeService.Value;
}

