using AutoMapper;
using Common.DTOs;
using Common.Requests;
using Common.Responses;
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
            CreateMap<ServiceModel, Service>().ReverseMap();
            CreateMap<ServiceDetailModel, ServiceDetail>().ReverseMap();
            CreateMap<ViewOrderResponse, Order>().
                ForPath(x => x.Customer.FirstName, opt => opt.MapFrom(x => x.FirstName)).
                ForPath(x => x.Customer.LastName, opt => opt.MapFrom(x => x.LastName))
                .ReverseMap();
            CreateMap<ResultModel, Result>().ReverseMap();
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
                .ReverseMap();
            CreateMap<OrderDetail, ViewOrderDetailResult>()
                .ForMember(x => x.ServiceName, opt => opt.MapFrom(x => x.Service.Name))
                .ReverseMap();
            CreateMap<OrderDetail, OrderDetailGeneralResponse>()
                .ForMember(_ => _.OrderCode, opt => opt.MapFrom(_ => _.Order.Code))
                .ForMember(_ => _.OrderDetailCode, opt => opt.MapFrom(_ => _.Code))
                .ForMember(_ => _.ServiceName, opt => opt.MapFrom(_ => _.Service.Name))
                .ForMember(_ => _.ServicePrice, opt => opt.MapFrom(_ => _.Price))
                .ReverseMap();
            CreateMap<OrderDetail, StaffOrderDetailsResponse>()
                .ForMember(_ => _.ServiceName, opt => opt.MapFrom(_ => _.Service.Name))
                .ForMember(_ => _.FinalPrice, opt => opt.MapFrom(_ => _.Result.DiamondValue))
                .ForMember(_ => _.OrderDetailCode, opt => opt.MapFrom(_ => _.Code))
                .ReverseMap();
            CreateMap<Order, ViewFullInfomaionOrder>()
                .ForMember(x => x.DetailValuations, opt => opt.MapFrom(x => x.DetailValuations));
            CreateMap<OrderDetail, ViewOrderDetail>();
        }
    }
}
