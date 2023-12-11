using System;
using System.Net;

namespace test2._0
{
	public class ExceptionHandlingMiddleware:IMiddleware
	{
		public ExceptionHandlingMiddleware()
		{

		}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            }catch(Exception ex)
            {
                context.Response.StatusCode =(int) HttpStatusCode.NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}

