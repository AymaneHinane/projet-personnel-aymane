using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Entities.Models;
using Project.Service.Contracts.security;
using Project.Shared.DataTransferObjects.Security;

namespace Project.Presentation.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
	public class AuthenticationController:ControllerBase
	{
		ISecurityServiceManager _securityServiceManager;

        public AuthenticationController(ISecurityServiceManager securityServiceManager)
		{
			_securityServiceManager = securityServiceManager;
		}


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (!ModelState.IsValid){

                return BadRequest(ModelState);
            }else{

                var result = await _securityServiceManager.AuthenticationService.RegisterUser(userForRegistration);

                if (result.Succeeded)

                    return StatusCode(201);
                else{

                    foreach (var error in result.Errors) { 
                      ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

            }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {

            var token = await _securityServiceManager.AuthenticationService.UserLogin(user);

            return Ok(token);
        }



        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var token = await _securityServiceManager.AuthenticationService.RefreshToken(tokenDto);

            return Ok(token);
        }

        [HttpGet("users")]
        [Authorize(Roles ="ADMIN")]
        public async Task<IActionResult> getAllUser()
        {
            var users = await _securityServiceManager.AuthenticationService.getAllUsers();

            return Ok(users);
        }

        [HttpGet("roles")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> getAllRoles()
        {
            return Ok(await _securityServiceManager.AuthenticationService.getAllRoles());
        }

    }
}

