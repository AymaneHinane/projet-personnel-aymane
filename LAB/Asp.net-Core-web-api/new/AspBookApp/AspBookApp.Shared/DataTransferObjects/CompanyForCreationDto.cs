

using System.ComponentModel.DataAnnotations;

namespace AspBookApp.Shared;

public class CompanyForCreationDto{
    [Required(ErrorMessage = "Company name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
   public string? Name {get;set;}

   [Required(ErrorMessage = "Company address is a required field.")]
   [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
   public string? Address {get;set;}


   [Required(ErrorMessage = "Company Country is a required field.")]
   [MaxLength(60, ErrorMessage = "Maximum length for the Country is 60 characters")]
   public string? Country {get;set;}



   public IEnumerable<EmployeeForCreationDto>? Employees {get;set;}
}