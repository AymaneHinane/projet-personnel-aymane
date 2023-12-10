
using Project.Entities.Models;
using Project.Shared.Request;

namespace Project.Contracts;


public interface ITransferQuery{
    IQueryable<Transfer> TransferFilterQuery(TransferParameters transferParameters);
}