
namespace Project.Service.Contracts;


public interface ITransferServiceManager{
    ITransferService transferService{get;}
    ITransferOperationService transferOperationService{get;}
}