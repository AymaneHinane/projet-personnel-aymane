using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using Project.Entities.Exceptions;
using Project.Entities.Models;
using Project.Service.Contracts.security;
using Project.Shared.DataTransferObjects.Security;

namespace Project.Service.security
{

    public class AuthenticationService : IAuthenticationService
    {

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<JwtConfig> _jwtConfig;
        private User? _user;

        public AuthenticationService(IMapper mapper, UserManager<User> userManager,
            IConfiguration configuration, 
            IOptions<JwtConfig> jwtConfig, RoleManager<IdentityRole> roleManager
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtConfig = jwtConfig;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);

            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);

            return result;
        }

        public async Task<TokenDto> UserLogin(UserForAuthenticationDto userForAuthenticationDto)
        {
            var existing_user = await _userManager.FindByNameAsync(userForAuthenticationDto.UserName);
            _user = existing_user;

            if (existing_user == null)
                throw new NotFoundException("the user is not found");

            if (!await _userManager.CheckPasswordAsync(existing_user, userForAuthenticationDto.Password))
                throw new BadRequestException("the password are not valid");



            var jwtToken = await GenerateJwtToken(true);

            return jwtToken;

        }

        private async Task<TokenDto> GenerateJwtToken(bool populateExp)
        {

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secret = _jwtConfig.Value.Secret;
            var key = Encoding.UTF8.GetBytes(secret);

            var claims = new List<Claim>
            {
               new Claim("Id", _user.Id),
               new Claim(ClaimTypes.Name, _user.UserName),
               new Claim(JwtRegisteredClaimNames.Name, _user.UserName), 
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _jwtConfig.Value.validIssuer,
                Audience = _jwtConfig.Value.validAudience,
                Subject = new ClaimsIdentity(claims),
                
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(_user);

            return new TokenDto()
            {
                AccessToken = jwtToken,
                RefreshToken = refreshToken,
                Identity = roles.FirstOrDefault(),
            };
        }


        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret)),
                ValidateLifetime = false,
                ValidIssuer = _jwtConfig.Value.validIssuer,
                ValidAudience = _jwtConfig.Value.validAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(tokenDto.AccessToken, tokenValidationParameters, out var securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                                                                  StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }


            var user = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            _user = user;

            return await GenerateJwtToken(populateExp: false);
        }

        public async Task<IEnumerable<UserInfoDto>> getAllUsers()
        {
           var users =  await this._userManager.Users.ToListAsync();

            var UsersInfo = new List<UserInfoDto>();

            foreach(var user in users)
            {
                var role = await this._userManager.GetRolesAsync(user);

                UsersInfo.Add(new() { id=user.Id, username = user.UserName, role = role.FirstOrDefault()});
            }

            return UsersInfo;

        }

        public async Task<List<IdentityRole>> getAllRoles()
        {
            var allRoles = await _roleManager.Roles.ToListAsync();

            return allRoles;
        }
    }
}

