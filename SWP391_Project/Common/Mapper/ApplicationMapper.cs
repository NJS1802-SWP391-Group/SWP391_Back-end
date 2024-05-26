using AutoMapper;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.Dtos;

namespace SWP391_Project.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<AccountModel, Account>().ReverseMap();
        }
    }
}
