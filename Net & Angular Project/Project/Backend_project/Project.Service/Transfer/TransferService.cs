
using AutoMapper;
using MediatR;
using Project.Contracts;
using Project.Contracts.Logger;
using Project.Entities.Event;
using Project.Entities.Exceptions;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Shared.Dto;
using Project.Shared.Request;

namespace Project.Service;

public class TransferService:ITransferService{

    private readonly ITransferRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IInventoryServiceManager _inventoryServiceManager;

     public TransferService(ITransferRepositoryManager repository, ILoggerManager logger,IMapper mapper,IMediator mediator,IInventoryServiceManager inventoryServiceManager)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _mediator = mediator;
        _inventoryServiceManager = inventoryServiceManager;
    }

    public async Task TransferInsert(TransferInsertDto transferDto)
    {
       var transfer =  _mapper.Map<Transfer>(transferDto);

       _repository.Transfer.TransferInsert(transfer);

        transfer.CreatedRaiseEvent();

        await _repository.SaveAsync();
    }


    public async Task AddNewDelivery(Guid transferId, TransferOperationInsertDto transferOperationInsertDto)
    {
       var transfer = await _repository.Transfer.GetTransferById(transferId,true);

       if(transfer == null )
          throw new NotFoundException($"the transfer with id {transferId} was not found");

       var transferOperation = _mapper.Map<TransferOperation>(transferOperationInsertDto);
              
       transfer.TransferOperations = new List<TransferOperation>();

       transfer.TransferOperations.Add(transferOperation);



       await _repository.SaveAsync();   
    }

    public async Task<IEnumerable<DestinationInfoDto?>> GetRecipientsByTransferId(Guid transferId)
    {
        var transfer = await _repository.Transfer.GetRecipientsByTransferId(transferId,false);

        return _mapper.Map<IEnumerable<DestinationInfoDto>>(transfer);
    }

    public async Task<ICollection<TransferOperationInfoDto>> GetTransferOperationByTransferId(Guid transferId) 
    { 
        var transferOperations = await _repository.TransferOperation.GetAllTransferOperationByTransferId(transferId,false);

        return _mapper.Map<ICollection<TransferOperationInfoDto>>(transferOperations);
    }

    public async Task<TransferOverviewDto?> TransferOverviewById(Guid transferId) => await
      _repository.Transfer.TransferOverviewById(transferId);


    public async Task UpdateTransfer(Guid transferId, TransferUpdateDto transferUpdate)
    {
        var transfer = await _repository.Transfer.GetTransferById(transferId);

        _mapper.Map(transferUpdate, transfer);

        transfer!.UpdatedRaiseEvent();

        await _repository.SaveAsync();
    }

}







    