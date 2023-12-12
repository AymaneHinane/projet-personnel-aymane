using System;
namespace Project.Service.Contracts.security
{
	public interface ISecurityServiceManager
	{
        IAuthenticationService AuthenticationService { get; }
    }
}

