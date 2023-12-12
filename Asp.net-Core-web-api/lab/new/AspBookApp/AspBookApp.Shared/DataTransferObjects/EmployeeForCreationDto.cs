
using System.ComponentModel.DataAnnotations;
namespace AspBookApp.Shared;


public class EmployeeForCreationDto{
    
    [Required(ErrorMessage = "Employee name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public  string? Name {get;init;}

    // [Required(ErrorMessage = "Age  is a required field.")]
    [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
    public  int Age {get;init;}

    [Required(ErrorMessage = "Position name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Position is 60 characters.")]
    public  string? Position {get;init;}   
}



