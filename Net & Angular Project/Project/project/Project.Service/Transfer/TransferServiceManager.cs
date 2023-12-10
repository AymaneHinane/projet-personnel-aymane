
using AutoMapper;
using MediatR;
using Project.Contracts;
using Project.Contracts.Logger;
using Project.Service.Contracts;

namespace Project.Service;


public class TransferServiceManager:ITransferServiceManager{
    
    private readonly Lazy<ITransferService> _transferService;
    private readonly Lazy<ITransferOperationService> _transferOperationService;

   

    public TransferServiceManager(ITransferRepositoryManager repository, ILoggerManager logger,IMapper mapper,IMediator mediator,IInventoryServiceManager inventoryServiceManager){
            _transferService = new Lazy<ITransferService>(()=>new TransferService(repository,logger,mapper,mediator,inventoryServiceManager));
            _transferOperationService = new Lazy<ITransferOperationService>(()=>new TransferOperationService(repository,logger,mapper,mediator));
    }


    public ITransferService transferService => _transferService.Value;
    public ITransferOperationService transferOperationService => _transferOperationService.Value;

}