using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Project.Contracts;
using Project.Entities.Models;
using Project.Service.Contracts;

namespace Project.Service.security
{

    public class WarehouseRoleRequirement : IAuthorizationRequirement
    {
        // You can add any additional properties or methods needed for checking the requirement.
    }


    public class WarehouseRoleHandler : AuthorizationHandler<WarehouseRoleRequirement>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInventoryServiceManager _inventoryServiceManager;



        public WarehouseRoleHandler(IHttpContextAccessor httpContextAccessor, IInventoryServiceManager inventoryServiceManager)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _inventoryServiceManager = inventoryServiceManager;
        }


        protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, WarehouseRoleRequirement requirement)
        {

            Guid warehouseId = new Guid(_httpContextAccessor.HttpContext.Request.RouteValues["warehouseId"].ToString());


            var userIdClaim = context.User.Claims.Where(x => x.Type == ClaimTypes.Role).ToList();



            if (warehouseId != null)
            {
                var warehouse = await _inventoryServiceManager.warehouseService.GetWarehouseById(warehouseId);

                if(warehouse != null)
                  if ( userIdClaim.Any(x => x.Value.Equals(warehouse.Name) || x.Value.Equals("ADMIN") ) )
                  { 
                    context.Succeed(requirement);
                  }
            }

            return Task.CompletedTask;
        }


    }


}

