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

        public async Task<StatusCodeResponse<RequestValuationFormModel>> GetRequestValuationFormById(int id)
        {
            var result = new StatusCodeResponse<RequestValuationFormModel>();
            try
            {
                var reqValuationForm = await _requestValuationFormRepo.FindByCondition(r => r.RequestValuationFormID == id && r.Status.ToUpper() == "Active".ToUpper()).FirstOrDefaultAsync();
                if (reqValuationForm != null)
                {
                    result.Data = _mapper.Map<RequestValuationFormModel>(reqValuationForm);
                    result.StatusCode = HttpStatusCode.OK;
                    result.Message = "OK";
                }
                else
                {
                    result.Data = _mapper.Map<RequestValuationFormModel>(reqValuationForm);
                    result.StatusCode = HttpStatusCode.NotFound;
                    result.Message = "Cannot find this form";
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
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

        public async Task<StatusCodeResponse<RequestValuationFormModel>> ChangeStatus(int id, string status)
        {
            var result = new StatusCodeResponse<RequestValuationFormModel>();
            try
            {
                var reqValuationForm = await _requestValuationFormRepo.FindByCondition(rvf => rvf.RequestValuationFormID == id).FirstOrDefaultAsync();
                reqValuationForm.Status = status;
                var data = _requestValuationFormRepo.Update(reqValuationForm);
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
