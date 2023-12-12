

using AutoMapper;
using MediatR;
using Project.Contracts;
using Project.Contracts.Logger;
using Project.Entities.Exceptions;
using Project.Entities.Models;
using Project.Service.Contracts;
using Project.Shared;
using Project.Shared.Dto;

namespace Project.Service;


public class TransferOperationService:ITransferOperationService{
    private readonly ITransferRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    private readonly IMapper _mapper;

    private readonly IMediator _mediator;

     public TransferOperationService(ITransferRepositoryManager repository, ILoggerManager logger,IMapper mapper,IMediator mediator)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _mediator = mediator;
    }



    public async Task UpdateTransferOperation(Guid Id,TransferOperationUpdateDto transferOperationUpdateDto)
    {
       var transferOperation = await _repository.TransferOperation.GetTransferOperationById(Id,true);
       
       _mapper.Map(transferOperationUpdateDto,transferOperation);

       

       await _repository.SaveAsync(); 
    } 
    
    public async Task UpdateRecipientTransfer(Guid tranferOperationId, ICollection<RecipientTransferUpdateDto> recipientsTransferUpdateDtos)
    {
        var recipientsTranfer = await _repository.TransferOperation.GetRecipientTransfersByTransferOperationId(tranferOperationId);
         
        foreach(var recipientTransferDto in recipientsTransferUpdateDtos){
           _mapper.Map(recipientTransferDto,recipientsTranfer.FirstOrDefault(x=>x.Id == recipientTransferDto.Id));
        }

        await _repository.SaveAsync();
    }

    
    public async Task AddVoucher(Guid transferOperationId,voucherType type,byte[] file){
        
        var transferOperation = await this._repository.TransferOperation.GetTransferOperationById(transferOperationId,true);

        if(transferOperation == null)
            throw new NotFoundException("transfer operation not found");

        if(type == voucherType.exit){
            transferOperation.ExitVoucher = file;

        }else if (type == voucherType.entry){
            transferOperation.EntryVoucher = file;
        }

        await _repository.SaveAsync();
    }

    public async Task<byte[]> GetVoucher(Guid transferOperationId, voucherType type)
    {
        var data  = await _repository.TransferOperation.GetVoucher(transferOperationId,type);
        return data!;
    }
}