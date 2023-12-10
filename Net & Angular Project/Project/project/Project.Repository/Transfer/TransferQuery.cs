
using AspBookApp.Repository;
using Project.Contracts;
using Project.Entities.Models;
using Project.Shared.Request;

namespace Project.Repository;


public class TransferQuery:RepositoryBase<Transfer>,ITransferQuery
{
    public TransferQuery(RepositoryContext repositoryContext) : base(repositoryContext){}

    public IQueryable<Transfer> TransferFilterQuery(TransferParameters transferParameters)
    {

      IQueryable<Transfer> filterQuery = repositoryContext.Transfers!;

      if(transferParameters.numero != null)
        filterQuery = filterQuery.Where(x=>x.Numero.Equals(transferParameters.numero));
      if(transferParameters.sender != null)
        filterQuery = filterQuery.Where(x=>x.Sender!.Name!.Equals(transferParameters.sender));
      if(transferParameters.recipient != null)
        filterQuery = filterQuery.Where(x=>x.Recipients!.Any(x=>x.Recipient!.Name!.Equals(transferParameters.recipient)));
      if(transferParameters.status != null)
        filterQuery = filterQuery.Where(x=>x.TransferStatus.Equals(transferParameters.status));
      if(transferParameters.recipientType != null)
        filterQuery = filterQuery.Where(x=>x.Recipients!.Any(x=>x.Recipient!.WarehouseType.Equals(transferParameters.recipientType)));
      if(transferParameters.region != null)
        filterQuery = filterQuery.Where(x=>x.Recipients!.Any(x=>x.Recipient!.WarehouseRegion.Equals(transferParameters.region)));
      if(transferParameters.product != null)
        filterQuery = filterQuery.Where(x=>x.Product!.Name!.Equals(transferParameters.product));
      if(transferParameters.qte != null)
        filterQuery = filterQuery.Where(x=>x.TransferedStockQuantity <= transferParameters.qte);
      if(transferParameters.deliveryDate != null)
        filterQuery = filterQuery.Where(x=>x.DeliveryDate.Equals(transferParameters.deliveryDate));
      if(transferParameters.shippedDate != null)
        filterQuery = filterQuery.Where(x=>x.DeliveryDate.Equals(transferParameters.shippedDate));

      return filterQuery;

    }

}
