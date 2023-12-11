using System;

namespace test6.Middleware
{
	public class ExceptionHandlingMiddleware:IMiddleware
	{
		public ExceptionHandlingMiddleware()
		{
		}

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}

