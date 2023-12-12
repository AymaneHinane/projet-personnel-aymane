using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Shared.DataTransferObjects.Security
{
	public class UserForAuthenticationDto
	{
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; init; }
    }
}

