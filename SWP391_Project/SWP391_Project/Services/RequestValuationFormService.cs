using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Common.Requests;
using SWP391_Project.Constants;
using SWP391_Project.Databases.Models;
using SWP391_Project.DTOs;
using SWP391_Project.Repositories.Interfaces;
using System.Net;

namespace SWP391_Project.Services
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
            try
            {
                var reqValuationForms = await _requestValuationFormRepo.GetAll().ToListAsync();
                var result = _mapper.Map<List<RequestValuationFormModel>>(reqValuationForms);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RequestValuationFormModel> GetById(int id)
        {
            try
            {
                var reqValuationForm = await _requestValuationFormRepo.FindByCondition(r => r.RequestValuationFormID == id).FirstOrDefaultAsync();
                var result = _mapper.Map<RequestValuationFormModel>(reqValuationForm);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StatusCodeResponse<RequestValuationFormModel>> CreateRequestValuationForm(CreateRequestValuationFormReq req)
        {
            var result = new StatusCodeResponse<RequestValuationFormModel>();
            try
            {
                var reqValuationForm = _mapper.Map<RequestValuationForm>(req);
                reqValuationForm.Status = "Active";
                var data = await _requestValuationFormRepo.AddAsync(reqValuationForm);
                await _requestValuationFormRepo.SaveChangesAsync();
                result.Data = _mapper.Map<RequestValuationFormModel>(data);
                result.StatusCode = HttpStatusCode.OK;
                result.Message = "OK";
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError; 
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }
    }
}
