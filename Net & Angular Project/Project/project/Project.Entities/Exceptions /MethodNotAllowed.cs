using System;
namespace Project.Entities.Exceptions
{
	public class MethodNotAllowed:Exception
	{
		public MethodNotAllowed(string message):base(message)
		{
		}
	}
}

