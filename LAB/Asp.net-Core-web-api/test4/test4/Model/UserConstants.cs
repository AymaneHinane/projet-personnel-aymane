using System;
namespace test4.Model
{
	public class UserConstants
	{
		public static List<UserModel> Users = new List<UserModel>()
		{
			new UserModel(){Username="jason_admin",EmailAdress="jason.admin@gmail.com",Password="MyPass_w0rd"
			,GivenName="Jason",Surname="Bryant",Role="administrator"},
			new UserModel(){Username="elyse_admin",EmailAdress="elyse.admin@gmail.com",Password="MyPass_w0rd"
			,GivenName="Elyse",Surname="Lambert",Role="Seller"}
		};
	}
}

