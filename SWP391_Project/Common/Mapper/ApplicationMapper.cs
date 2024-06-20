using AutoMapper;
using Common.DTOs;
using Common.Requests;
using Common.Responses;
using Domain.DiamondEntities;
using Domain.DiavanEntities;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.Dtos;
using SWP391_Project.DTOs;
using System.Security.Cryptography.X509Certificates;

namespace SWP391_Project.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<AccountModel, Account>().ReverseMap();
            CreateMap<CustomerModel, Customer>().ReverseMap();
            CreateMap<ServiceModel, Service>().ReverseMap();
            CreateMap<ServiceDetailModel, ServiceDetail>().ReverseMap();
            CreateMap<ViewOrderResponse, Order>().
                ForPath(x => x.Customer.FirstName, opt => opt.MapFrom(x => x.FirstName)).
                ForPath(x => x.Customer.LastName, opt => opt.MapFrom(x => x.LastName))
                .ReverseMap();
            CreateMap<ResultModel, Result>().ReverseMap();
            CreateMap<GetResultByIdResponse, Result>().ReverseMap();
            CreateMap<ResultImages, ResultImage>().ReverseMap();
            CreateMap<CreateResultReq, Result>()
                .ForMember(x => x.Status, opt => opt.MapFrom(x => "Pending")).ReverseMap();
            CreateMap<UpdateResultReq, Result>().ReverseMap();
            CreateMap<GetServiceDetailPriceResponse, ServiceDetail>()
                .ForMember(x => x.ServiceDetailID, opt => opt.MapFrom(x => x.ServiceDetailID))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price)).ReverseMap();
            CreateMap<CreateOrderReq, Order>().ReverseMap();
            CreateMap<UpdateOrderConsult, Order>()
                .ForMember(x => x.DetailValuations, opt => opt.MapFrom(x => x.DetailValuations))
                .ReverseMap();
            CreateMap<OrderDetail, OrderDetailCreate>()
                .ReverseMap();
            CreateMap<ViewOrderResult, Order>()
                .ForMember(x => x.DetailValuations, opt => opt.MapFrom(x => x.DetailValuations))
                .ForPath(x => x.Customer.FirstName, opt => opt.MapFrom(x => x.FirstName)).
                 ForPath(x => x.Customer.LastName, opt => opt.MapFrom(x => x.LastName))
                .ReverseMap();
            CreateMap<OrderDetail, ViewOrderDetailResult>()
                .ForMember(x => x.ServiceName, opt => opt.MapFrom(x => x.Service.Name))
                .ReverseMap();
            CreateMap<OrderDetail, OrderDetailGeneralResponse>()
                .ForMember(_ => _.OrderCode, opt => opt.MapFrom(_ => _.Order.Code))
                .ForMember(_ => _.OrderDetailCode, opt => opt.MapFrom(_ => _.Code))
                .ForMember(_ => _.ServiceName, opt => opt.MapFrom(_ => _.Service.Name))
                .ForMember(_ => _.ServicePrice, opt => opt.MapFrom(_ => _.Price))
                .ForMember(_ => _.ValuatingStaffName, opt => opt.MapFrom(_ => _.ValuationStaff.UserName))
                .ReverseMap();
            CreateMap<OrderDetail, StaffOrderDetailsResponse>()
                .ForMember(_ => _.ServiceName, opt => opt.MapFrom(_ => _.Service.Name))
                .ForMember(_ => _.FinalPrice, opt => opt.MapFrom(_ => _.Result.DiamondValue))
                .ForMember(_ => _.OrderDetailCode, opt => opt.MapFrom(_ => _.Code))
                .ReverseMap();
            CreateMap<OrderDetail, GetDoneOrderDetailsResponse>()
                .ForMember(_ => _.ResultId, opt => opt.MapFrom(_ => _.Result.ResultId))
                .ForMember(_ => _.OrderCode, opt => opt.MapFrom(_ => _.Order.Code))
                .ForMember(_ => _.OrderDetailCode, opt => opt.MapFrom(_ => _.Code))
                .ForMember(_ => _.ServiceName, opt => opt.MapFrom(_ => _.Service.Name))
                .ForMember(_ => _.ValuationStaffName, opt => opt.MapFrom(_ => _.ValuationStaff.UserName))
                .ForMember(_ => _.ValuatingPrice, opt => opt.MapFrom(_ => _.Result.DiamondValue))
                .ForMember(_ => _.Status, opt => opt.MapFrom(_ => _.Status))
                .ReverseMap();
            CreateMap<Order, ViewFullInfomaionOrder>()
                .ForMember(x => x.DetailValuations, opt => opt.MapFrom(x => x.DetailValuations))
                 .ForPath(x => x.FirstName, opt => opt.MapFrom(x => x.Customer.FirstName)).
                 ForPath(x => x.LastName, opt => opt.MapFrom(x => x.Customer.LastName))
                 .ReverseMap();
            CreateMap<Order, GetOrderToSendMail>()
                 .ForMember(x => x.DetailValuations, opt => opt.MapFrom(x => x.DetailValuations))
                 .ForPath(x => x.FirstName, opt => opt.MapFrom(x => x.Customer.FirstName)).
                 ForPath(x => x.LastName, opt => opt.MapFrom(x => x.Customer.LastName))
                 .ForMember(x=>x.DetailValuations,opt =>opt.MapFrom(x=>x.DetailValuations))
                 .ReverseMap();
            CreateMap<ViewOrderDetailModel,OrderDetail>().
                ForPath(x=>x.Price,opt =>opt.MapFrom(x=>x.ServicePrice))
                .ReverseMap();
            CreateMap<OrderDetail, ViewOrderDetail>().ReverseMap();
            CreateMap<OrderDetail, ViewOrderDetail>().ReverseMap();
            CreateMap<SystemDiamond, Diamond>()
                .ForMember(d => d.DiamondId, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(sd => sd.DiamondId, opt => opt.Ignore());
            CreateMap<OrderDetail, ViewOrderDetail>();
            CreateMap<DimondCheckInformation, DiamondCheck>()
                .ForMember(x=>x.DiamondCheckValues,opt => opt.MapFrom(x=>x.DiamondCheckValues))
                .ReverseMap();
            CreateMap<DiamondCheckValue,DiamondCheckValueDto>()
                .ReverseMap();
            CreateMap<DiamondModel, SystemDiamond>().ReverseMap();
        }
    }
}
