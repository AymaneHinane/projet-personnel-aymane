using System;
using Microsoft.EntityFrameworkCore;
using test.DB;
using test.Models;
using test.ModelsSearch;

namespace test.Repository.CommandeRepository
{
	public class CommandeRepository:ICommandeRepository
	{
		private readonly DBContext _context;

		public CommandeRepository(DBContext context) => _context = context;


        public async Task AddNewCommande(Commande commande)
        {
            await _context.Commandes.AddAsync(commande);
            await _context.SaveChangesAsync();
            
        }

        public async Task AddProductCommande(int id, ProductCommande product)
        {

            // var commande = await _context.Commandes.Where(x => x.Id == id).FirstOrDefaultAsync();

            var commande = await _context.Commandes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (commande != null && commande.ProductCommandes != null)
            {
                commande.ProductCommandes.Add(product);
                //product.CommandeId = id;
                //await _context.ProductCommandes.AddAsync(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddProductsCommande(int id, List<ProductCommande> Listproducts)
        {
            var commande = await _context.Commandes.Where(x => x.Id == id)
                           .Include(x=>x.ProductCommandes)
                           .FirstOrDefaultAsync();

            if(commande != null && commande.ProductCommandes != null)
            {
                commande.ProductCommandes.AddRange(Listproducts);
                _context.SaveChanges();
            }
           
        }


        public async  Task<List<CommandeDetails>> CommandeDetails(int commandeId)
        {
            var data = await _context.commandeDetails.FromSqlRaw("Execute [dbo].[CommandeDetails] {0}", commandeId).ToListAsync();
            return data; 

        }


        public async Task<ClientOrder> CountCommandeClient(int id)
        {
            var data=await _context.Commandes
                              .GroupBy(o=>new { Id = o.ClientId})
                              .Select(c => new ClientOrder()
                              {
                                  ClientId = c.Key.Id,
                                  OrderQte =c.Count()   //m.Sum(m=>m.col)
                              })
                              .Where(x=>x.ClientId==id).FirstOrDefaultAsync();

           

            return data;

        }

        public async Task<Commande> GetProductCommande(int commandeId)
        {
            //    var data1 = await _context.Commandes
            //        .AsNoTracking()
            //        .Select(x => new Commande{Id= x.Id,Products= x.Products,Client= x.Client,ProductCommandes=x.ProductCommandes})
            //        .FirstOrDefaultAsync();


            var data1 = await _context.Commandes.SingleOrDefaultAsync(x => x.Id == commandeId);

           // var data2 = data1.Client.LastName;
          

            return data1;
        }


    }
}

