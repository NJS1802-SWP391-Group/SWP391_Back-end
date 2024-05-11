using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Databases.Models;
using SWP391_Project.DTOs;
using SWP391_Project.Repositories.Interfaces;

namespace SWP391_Project.Service
{
    public class RequestValuationFormService
    {
        private readonly IRepository<RequestValuationForm, int> _requestValuationFormRepo;
        private readonly IMapper _mapper;

        public RequestValuationFormService(IRepository<RequestValuationForm, int> requestValuationFormRepo, IMapper mapper)
        {
            _requestValuationFormRepo = requestValuationFormRepo;
            _mapper = mapper;
        }

        public async Task<List<RequestValuationFormModel>> GetAll()
        {
            var reqValuationForms = await _requestValuationFormRepo.GetAll().ToListAsync();
            var result = _mapper.Map<List<RequestValuationFormModel>>(reqValuationForms);
            return result;
        }

        public async Task<RequestValuationFormModel> GetById(int id)
        {
            var reqValuationForm = await _requestValuationFormRepo.FindByCondition(r => r.RequestValuationFormID == id).FirstOrDefaultAsync();
            var result = _mapper.Map<RequestValuationFormModel>(reqValuationForm);
            return result;
        }
    }
}
