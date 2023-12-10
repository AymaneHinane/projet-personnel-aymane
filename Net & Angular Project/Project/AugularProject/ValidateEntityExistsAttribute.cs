using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project.Contracts;

namespace Project.Shared.ActionFilter
{
    public class ValidateEntityExistsAttribute<T> : IActionFilter where T : class
    {
        private readonly RepositoryContext repositoryContext;

        public ValidateEntityExistsAttribute(RepositoryContext repositoryContext)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           // throw new NotImplementedException();
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            Guid id = Guid.Empty;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (Guid)context.ActionArguments["id"];
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad id parameter");
                return;
            }

            var entity =await _inventoryRepositoryManager.Warehouse.GetWarehouseById(id, false);

            if (entity == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }

        }

    }
}

