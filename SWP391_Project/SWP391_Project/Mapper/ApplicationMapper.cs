using AutoMapper;
using SWP391_Project.Common.Requests;
using SWP391_Project.Databases.Models;
using SWP391_Project.Dtos;
using SWP391_Project.DTOs;

namespace SWP391_Project.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<RequestValuationForm, RequestValuationFormModel>().ReverseMap();
            CreateMap<CreateRequestValuationFormReq, RequestValuationForm>().ReverseMap();
            CreateMap<ScheduleFormModel, ScheduleForm>().ReverseMap();
        }
    }
}
