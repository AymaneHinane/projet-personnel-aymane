


namespace AspBookApp.Shared;


public class CompanyEmployeeDto{
    public Guid Id {get;set;}
    public string? Name {get;set;}
    public string? FullAddress {get;set;}

     public ICollection<EmployeeDto>? Employees { get; set; }
}