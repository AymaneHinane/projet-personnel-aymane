using AutoMapper;
using Project.Entities.Models;
using Project.Shared.DataTransferObjects.Invoice;
using Project.Shared.DataTransferObjects.Security;
using Project.Shared.Dto;



public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Warehouse,WarehouseInfoDto>();
        CreateMap<ProductUpdateDto,Stock>()
        .ForAllMembers(opt=>opt.Condition((src,dest,prop,context)=>prop!=null));


        CreateMap<Warehouse,WarehouseRawMaterilaStockDto>()
          .ForMember(dest=>dest.category,opt=>opt.MapFrom(src=>src.Stocks!.First().product!.category));

        CreateMap<Warehouse,WarehouseFinishedProductStockDto>()
          .ForMember(dest=>dest.category,opt=>opt.MapFrom(src=>src.Stocks!.First().product!.category));

        CreateMap<Stock,RawMaterilaStockDto>()
          .ForMember(dest=>dest.productName,opt=>opt.MapFrom(src=>src.product!.Name));

        CreateMap<Stock,FinishedProductStockDto>()
        .ForMember(dest=>dest.productName,opt=>opt.MapFrom(src=>src.product!.Name));



        //transfert

        CreateMap<TransferInsertDto, Transfer>();
          //.ForMember(dest=>dest.DeliveredStockQuantity,opt=>opt.MapFrom(src=>src.TransferedStockQuantity));


        CreateMap<RecipientInsertDto,Recipients>();


        CreateMap<TransferOperationInsertDto,TransferOperation>();
        CreateMap<RecipientTransferInsertDto,RecipientTransfer>();


        CreateMap<Warehouse,DestinationInfoDto>();
          

        CreateMap<Product,ProductInfoDto>();

        CreateMap<Recipients,DestinationInfoDto>()
          .ForMember(dest=>dest.Name,opt=>opt.MapFrom(x=>x.Recipient!.Name));
          

        CreateMap<Transfer,TransferInfoDto>();
        
        CreateMap<TransferOperation,TransferOperationInfoDto>()
          .ForMember(dest=>dest.RecipientTransfer,opt=>opt.MapFrom(src=>src.RecipientTransfers))
          .ForMember(dest => dest.ExitVoucherExist, opt => opt.MapFrom(src => src.ExitVoucher != null && src.ExitVoucher.Length > 0))
          .ForMember(dest => dest.EntryVoucherExist, opt => opt.MapFrom(src => src.EntryVoucher != null && src.EntryVoucher!.Length > 0));

        CreateMap<RecipientTransfer,RecipientTransferInfoDto>()
           .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Recipient!.Recipient!.Name));


        CreateMap<TransferOperationUpdateDto,TransferOperation>()
          .ForMember(dest=>dest.EntryStockWeight,opt=>opt.Condition(src=>src.EntryStockWeight != null ))
          .ForMember(dest=>dest.ExitStockWeight,opt=>opt.Condition(src=>src.ExitStockWeight != null ))
          .ForAllMembers(opt=>opt.Condition((src,dest,prop,context)=>prop!=null));

         CreateMap<TransferUpdateDto,Transfer>()
           .ForMember(dest=>dest.TransferedStockQuantity,opt=>opt.Condition(src=>src.TransferedStockQuantity != null))
           .ForMember(dest=>dest.DeliveredStockQuantity,opt=>opt.Condition(src=>src.DeliveredStockQuantity != null))
           .ForAllMembers(opt => opt.Condition((src, dest, prop, context) => prop != null));

        CreateMap<RecipientTransferUpdateDto,RecipientTransfer>()
          .ForMember(dest=>dest.DeliveredStock,opt=>opt.Condition(src=>src.DeliveredStock != null))
          .ForAllMembers(opt=>opt.Condition((src,dest,prop,context)=>prop!=null));


        //Invoice

        CreateMap<InvoiceCreateDto, Invoice>()
            .ForMember(dest => dest.InvoicePdf, opt => opt.Ignore());

        CreateMap<InvoiceCategory, InvoiceCategoryInfoDto>();

        CreateMap<Invoice, InvoiceInfoDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.InvoiceCategory!.Category));



        CreateMap<UserForRegistrationDto, User>();

    }

}

