


using System.ComponentModel.DataAnnotations;

namespace AspBookApp.Shared;


public class EmployeeForManipulationDto{


    [Required(ErrorMessage = "Employee name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string? Name;

    [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
    public int Age;

    [Required(ErrorMessage = "Position name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Position is 60 characters.")]
    public string? Position;
}