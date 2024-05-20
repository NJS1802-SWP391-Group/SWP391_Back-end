//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using SWP391_Project.Common.Requests;
//using SWP391_Project.Constants;
//using SWP391_Project.Databases.System.Models;
//using SWP391_Project.DTOs;
//using SWP391_Project.Repositories.Interfaces;
//using System.Net;

//namespace SWP391_Project.Services
//{
//    public class ScheduleFormService
//    {
//        private readonly IRepository<ScheduleForm, int> _scheduleFormRepo;
//        private readonly IRepository<RequestValuationForm, int> _requestValuationFormRepo;
//        private readonly IMapper _mapper;
        
//        public ScheduleFormService() { }

//        public ScheduleFormService(IRepository<ScheduleForm, int> scheduleFormRepo, IRepository<RequestValuationForm, int> requestValuationFormRepo, IMapper mapper)
//        {
//            _scheduleFormRepo = scheduleFormRepo;
//            _requestValuationFormRepo = requestValuationFormRepo;
//            _mapper = mapper;
//        }

//        public async Task<StatusCodeResponse<List<ScheduleFormModel>>> GetAllActiveScheduleForm()
//        {
//            try
//            {
//                var scheduleForms = await _scheduleFormRepo.GetAll().Where(s => s.Status.ToLower().Trim() == "active").ToListAsync();
//                if (scheduleForms.Any())
//                {
//                    return new StatusCodeResponse<List<ScheduleFormModel>>()
//                    {
//                        Data = _mapper.Map<List<ScheduleFormModel>>(scheduleForms),
//                        StatusCode = HttpStatusCode.OK,
//                        Message = "OK",
//                    };
//                }
//                else
//                {
//                    return new StatusCodeResponse<List<ScheduleFormModel>>()
//                    {
//                        Data = _mapper.Map<List<ScheduleFormModel>>(scheduleForms),
//                        StatusCode = HttpStatusCode.NotFound,
//                        Message = "No schedule form available",
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                return new StatusCodeResponse<List<ScheduleFormModel>>()
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    Message = ex.Message,
//                    Data = null,
//                };
//            }
//        }

//        public async Task<StatusCodeResponse<ScheduleFormModel>> GetScheduleFormById(int id)
//        {
//            try
//            {
//                var scheduleForms = await _scheduleFormRepo.FindByCondition(s => s.Status.ToLower().Trim() == "active").FirstOrDefaultAsync();
//                if (scheduleForms is null)
//                {
//                    return new StatusCodeResponse<ScheduleFormModel>()
//                    {
//                        Data = _mapper.Map<ScheduleFormModel>(scheduleForms),
//                        StatusCode = HttpStatusCode.OK,
//                        Message = "OK",
//                    };
//                }
//                else
//                {
//                    return new StatusCodeResponse<ScheduleFormModel>()
//                    {
//                        Data = _mapper.Map<ScheduleFormModel>(scheduleForms),
//                        StatusCode = HttpStatusCode.NotFound,
//                        Message = "No schedule form available",
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                return new StatusCodeResponse<ScheduleFormModel>()
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    Message = ex.Message,
//                    Data = null,
//                };
//            }
//        }

//        public async Task<StatusCodeResponse<ScheduleFormModel>> CreateScheduleForm(CreateScheduleFormReq req)
//        {
//            try
//            {
//                var scheduleForms = await _scheduleFormRepo.AddAsync(new ScheduleForm
//                {
//                    Time = req.Time,
//                    ConsultStaffID = req.ConsultStaffID,
//                    CustomerID = req.CustomerID,
//                    RequestValuationFormID = req.RequestValuationFormID,
//                    Status = "Active"
//                });
//                if (scheduleForms != null)
//                {
//                    await _scheduleFormRepo.SaveChangesAsync();
//                    return new StatusCodeResponse<ScheduleFormModel>()
//                    {
//                        Data = _mapper.Map<ScheduleFormModel>(scheduleForms),
//                        StatusCode = HttpStatusCode.OK,
//                        Message = "OK",
//                    };
//                }
//                else
//                {
//                    return new StatusCodeResponse<ScheduleFormModel>()
//                    {
//                        Data = _mapper.Map<ScheduleFormModel>(scheduleForms),
//                        StatusCode = HttpStatusCode.NotFound,
//                        Message = "Cannot create schedule form",
//                    };
//                }
//            }
//            catch(Exception ex)
//            {
//                return new StatusCodeResponse<ScheduleFormModel>()
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    Message = ex.Message,
//                    Data = null,
//                };
//            }
//        }

//        public async Task<StatusCodeResponse<ScheduleFormModel>> ChangeStatus(int id, string status)
//        {
//            try
//            {
//                var scheduleForm = await _scheduleFormRepo.FindByCondition(rvf => rvf.ScheduleFormID == id).FirstOrDefaultAsync();
//                if (scheduleForm != null)
//                {
//                    scheduleForm.Status = status;
//                    var data = _scheduleFormRepo.Update(scheduleForm);
//                    await _requestValuationFormRepo.SaveChangesAsync();
//                    return new StatusCodeResponse<ScheduleFormModel>()
//                    {
//                        Data = _mapper.Map<ScheduleFormModel>(data),
//                        StatusCode = HttpStatusCode.OK,
//                        Message = "OK",
//                    };
//                }
//                else
//                {
//                    return new StatusCodeResponse<ScheduleFormModel>()
//                    {
//                        Data = null,
//                        StatusCode = HttpStatusCode.BadRequest,
//                        Message = "Cannot upate",
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                return new StatusCodeResponse<ScheduleFormModel>()
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    Message = ex.Message,
//                    Data = null,
//                };
//            }
//        }
//    }
//}
