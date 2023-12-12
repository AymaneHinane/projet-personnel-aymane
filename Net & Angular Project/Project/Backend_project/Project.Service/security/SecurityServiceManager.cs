using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Project.Entities.Models;
using Project.Service.Contracts.security;

namespace Project.Service.security
{
	public class SecurityServiceManager: ISecurityServiceManager
    {
		private readonly Lazy<IAuthenticationService> _authenticationService;

		public SecurityServiceManager(IMapper _mapper, UserManager<User> userManager,IConfiguration configuration ,IOptions<JwtConfig> jwtConfig,RoleManager<IdentityRole> roleManager)
		{
			_authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_mapper, userManager, configuration, jwtConfig,roleManager));
		}

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}

