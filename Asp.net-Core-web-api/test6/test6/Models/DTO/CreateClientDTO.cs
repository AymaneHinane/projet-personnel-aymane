using System;
using System.ComponentModel.DataAnnotations;

namespace test6.Models.DTO
{
	public class CreateClientDTO
	{
        //[Required ]
        [StringLength(20,ErrorMessage ="the Fisrt Name is very Long")]
        public string FirstName { get; set; }

        //[Required]
        [StringLength(20, ErrorMessage = "the Last Name is very Long")]
        public string LastName { get; set; } 

        //[Required]
        [StringLength(50, ErrorMessage = "the email address Name is very Long")]
        public string? EmailAddress { get; set; }

       // [Required]
        public Address Address { get; set; }
    }
}

