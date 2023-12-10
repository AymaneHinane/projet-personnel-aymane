using System;
using Microsoft.AspNetCore.Identity;
using Project.Entities.Models;
using Project.Shared.DataTransferObjects.Security;

namespace Project.Service.Contracts.security
{
	public interface IAuthenticationService
	{
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<TokenDto> UserLogin(UserForAuthenticationDto userForAuthenticationDto);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<IEnumerable<UserInfoDto>> getAllUsers();
        Task<List<IdentityRole>> getAllRoles();
    }
}

