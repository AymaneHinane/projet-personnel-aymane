

namespace AspBookApp.Shared;

//public record CompanyDto(Guid Id, string Name, string FullAddress);

public class CompanyDto
{
    public Guid Id {get;set;}
    public string? Name {get;set;}
    public string? FullAddress {get;set;}
}
