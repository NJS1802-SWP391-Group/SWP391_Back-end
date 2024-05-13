using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Constants;
using SWP391_Project.Databases.Models;
using SWP391_Project.DTOs;
using SWP391_Project.Repositories.Interfaces;
using System.Net;

namespace SWP391_Project.Services
{
    public class ScheduleFormService
    {
        private readonly IRepository<ScheduleForm, int> _scheduleFormRepo;
        private readonly IMapper _mapper;
        
        public ScheduleFormService() { }

        public ScheduleFormService(IRepository<ScheduleForm, int> scheduleFormRepo, IMapper mapper)
        {
            _scheduleFormRepo = scheduleFormRepo;
            _mapper = mapper;
        }

        public async Task<StatusCodeResponse<List<ScheduleFormModel>>> GetAllScheduleForm()
        {
            var result = new StatusCodeResponse<List<ScheduleFormModel>>();
            try
            {
                var scheduleForms = await _scheduleFormRepo.GetAll().ToListAsync();
                if (scheduleForms != null)
                {
                    result.Data = _mapper.Map<List<ScheduleFormModel>>(scheduleForms);
                    result.StatusCode = HttpStatusCode.OK;
                    result.Message = "OK";
                }
                else
                {
                    result.Data = _mapper.Map<List<ScheduleFormModel>>(scheduleForms);
                    result.StatusCode = HttpStatusCode.NotFound;
                    result.Message = "No schedule form available";
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
    }
}
