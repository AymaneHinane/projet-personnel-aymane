using System;
namespace Project.Shared.DataTransferObjects.Security
{

	public class TokenDto {
		public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
		public string Identity { get; set; }
		public Guid? warehouseId { get; set; }
    }

	
}

