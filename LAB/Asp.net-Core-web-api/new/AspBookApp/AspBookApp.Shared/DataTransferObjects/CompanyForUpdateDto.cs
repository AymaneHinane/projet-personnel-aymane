

using System.ComponentModel.DataAnnotations;

namespace AspBookApp.Shared;


public class CompanyForUpdateDto{

    [MaxLength(60, ErrorMessage = "company Maximum length for the Name is 60 characters.")]
    public string? Name;
    [MaxLength(60, ErrorMessage = "company Maximum length for the Name is 60 characters.")]
    public string? Address;
    [MaxLength(60, ErrorMessage = "company Maximum length for the Name is 60 characters.")]
    public string? Country;
    IEnumerable<EmployeeForCreationDto>? Employees;
    
}