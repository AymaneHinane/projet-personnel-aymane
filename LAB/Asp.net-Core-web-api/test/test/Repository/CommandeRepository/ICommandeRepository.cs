using System;
using test.Models;
using test.ModelsSearch;

namespace test.Repository.CommandeRepository
{
	public interface ICommandeRepository
	{

		Task AddNewCommande(Commande commande);
		Task AddProductCommande(int id, ProductCommande product);
		Task<ClientOrder> CountCommandeClient(int clientId);
		Task<Commande> GetProductCommande(int commandeId);
		Task<List<CommandeDetails>> CommandeDetails(int commandeId);
		Task AddProductsCommande(int id, List<ProductCommande> Listproducts);
	}
}

