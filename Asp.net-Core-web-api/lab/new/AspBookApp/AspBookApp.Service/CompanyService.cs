

using AspBookApp.Contracts.LoggerManager;
using AspBookApp.Contracts.Repository;
using AspBookApp.Entities.Exceptions;
using AspBookApp.Entities.Models;
using AspBookApp.Service.Contracts;
using AspBookApp.Shared;
using AutoMapper;
//using AspBookApp.Service.Contracts;

namespace AspBookApp.Service;



internal sealed class CompanyService : ICompanyService
{
    private IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    private readonly IMapper _mapper;
    public CompanyService(IRepositoryManager repository, ILoggerManager logger,IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
    {
              var companies =await _repository.Company.GetAllCompaniesAsync(trackChanges); 
              var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
              
              return companiesDto;
    }

    public async Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges)
    {

      var company =await _repository.Company.GetCompanyAsync(companyId, trackChanges); //Check if the company is null

      if(company is null)
      {   
        _logger.LogError("company not found");
        throw new CompanyNotFoundException(companyId);
      }

      var companyDto = _mapper.Map<CompanyDto>(company);
      return companyDto;
     
    }

    public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
    {
        var companyEntity = _mapper.Map<Company>(company);
        _repository.Company.CreateCompany(companyEntity);
        await _repository.SaveAsync();
        
        var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

        return companyToReturn;  
    }

    public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
       if (ids is null)
          throw new IdParametersBadRequestException();

       var companyEntities =await _repository.Company.GetByIdsAsync(ids, trackChanges); 

       if (ids.Count() != companyEntities.Count())
            throw new CollectionByIdsBadRequestException();

       var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
       return companiesToReturn;
    }

    public async Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection)
    {
        if (companyCollection is null)
           throw new CompanyCollectionBadRequest();

        var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);

        foreach (var company in companyEntities)
        {
          _repository.Company.CreateCompany(company);
        } 

        await _repository.SaveAsync();
        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

        _logger.LogInfo(ids);

         return (companies: companyCollectionToReturn, ids: ids);
    }

    public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges) {

       var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges); 

       if (company is null)
          throw new CompanyNotFoundException(companyId);
          
       _repository.Company.DeleteCompany(company);
       await _repository.SaveAsync();
    }

    public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
    {
       var companyEntity = await _repository.Company.GetCompanyAsync(companyId, trackChanges);

       if (companyEntity is null)
           throw new CompanyNotFoundException(companyId);

       _mapper.Map(companyForUpdate, companyEntity);
       await _repository.SaveAsync();
       
    }

    public async Task<CompanyEmployeeDto> GetCompanyWithEmployeeAsync(Guid companyId, bool trackChanges)
    {

      var companyEntity = await _repository.Company.GetCompanyWithEmployeeAsync(companyId,trackChanges);
      var companiesDto = _mapper.Map<CompanyEmployeeDto>(companyEntity);

      return companiesDto; 
    }

}