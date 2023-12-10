using System;
namespace Project.Entities.Models
{
	public class JwtConfig
	{
		public string Secret { get; set; }
		public TimeSpan ExpiryTimeFrame { get; set; }
		public string validIssuer { get; set; }
		public string validAudience { get; set; }
    }
}

