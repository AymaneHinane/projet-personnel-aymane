using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.DB;
using test.Models;

namespace test.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
	public class Test:ControllerBase
	{
		private readonly DBContext context;

		public Test(DBContext context)
        {
			this.context = context;
        }


        [HttpGet]
		public IActionResult get()
        {

            //var data = from client in context.Clients
            //           where client.FirstName.Contains("ell")
            //           select client;


            //var data = from client in context.Clients
            //           where client.FirstName.Contains("ell")
            //           orderby client.LastName descending
            //           select new
            //           {
            //               client= client
            //           };

            //var data = from Commande in context.Commandes
            //           group Commande by Commande.ClientId into CommandeId
            //           select new
            //           {
            //               Id = CommandeId.Key,
            //               Commande = CommandeId.ToList()
            //           };

            // var data = context.Commandes.GroupBy(x => x.ClientId).Select(x=> new { Id=x.Key,Commande=x.ToList()}).ToList();

            //var data = from client in context.Clients
            //           //group client by client.Id into clientId
            //           join commande in context.Commandes on client.Id equals commande.ClientId
            //           select new { clientId = client.Id, commande = commande };


            //var data = from client in context.Clients
            //           group client by client.Id into clientId
            //           join commande in context.Commandes on clientId.Key equals commande.ClientId
            //           select new { clientId = clientId, commande = commande };

            //var data = from client in context.Clients
            //           join commande in context.Commandes on client.Id equals commande.ClientId into groupe
            //           select groupe;


            //var data = from commande in context.Commandes
            //           group commande by commande.EmployeeId into cmdId
            //           where cmdId.Key == 5
            //           select new
            //           {
            //               magasin = cmdId.Select(m => new
            //               {
            //                   m.Employee.Magasin
            //               }).Distinct()
            //           };


            //var data = context.Commandes.GroupBy(x => new { x.ProductCommandes, x.Products, x.Id })
            //           .Select(x => new
            //           {
            //               Commande = x.Select(c => new { c.Id })
            //           });


             var data = context.Clients.Filter(x => x.Id == 1);


            return Ok(data);           
        }

	}
}

