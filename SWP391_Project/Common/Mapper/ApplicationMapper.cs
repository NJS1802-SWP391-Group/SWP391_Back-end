using AutoMapper;
using Common.Requests;
using Common.Responses;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.Dtos;
using SWP391_Project.DTOs;

namespace SWP391_Project.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<AccountModel, Account>().ReverseMap();
            CreateMap<ServiceModel, Service>().ReverseMap();
            CreateMap<ServiceDetailModel, ServiceDetail>().ReverseMap();
            CreateMap<ViewOrderResponse,Order>().ReverseMap();
            CreateMap<GetServiceDetailPriceResponse, ServiceDetail>()
                .ForMember(x => x.ServiceDetailID, opt => opt.MapFrom(x => x.ServiceDetailID))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price)).ReverseMap();
            CreateMap<CreateOrderReq, Order>().ReverseMap();
            CreateMap<UpdateOrderConsult, Order>()
                //.ForMember(x => x.DetailValuations, opt => opt.MapFrom(x => x.DetailValuations))
                .ReverseMap();
            CreateMap<OrderDetail, OrderDetailCreate>()
                .ReverseMap();
            CreateMap<ViewOrderResult, Order>()
                .ForMember(x => x.DetailValuations, opt => opt.MapFrom(x => x.Details))
                .ReverseMap();
            CreateMap<OrderDetail,ViewOrderDetailResult>().ReverseMap();
        }
    }
}
