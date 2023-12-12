

using AspBookApp.Entities.Models;
using AspBookApp.Shared;
using AutoMapper;

namespace AspBookApp.Api.Configuartion.Mapping;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
              .ForMember(dest => dest.FullAddress,
              act => act.MapFrom(x => string.Join(' ', x.Address, x.Country)));

        CreateMap<Company,CompanyEmployeeDto>()
              .ForMember(dest => dest.FullAddress,
              act => act.MapFrom(x => string.Join(' ', x.Address, x.Country)));
              

        CreateMap<Employee, EmployeeDto>();

        CreateMap<CompanyForCreationDto, Company>();

        CreateMap<EmployeeForCreationDto,Employee>();

        CreateMap<EmployeeForUpdateDto, Employee>();

        CreateMap<CompanyForUpdateDto, Company>();

    }   
}
