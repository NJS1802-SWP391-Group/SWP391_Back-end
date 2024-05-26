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
//    public class RequestValuationFormService
//    {
//        private readonly IRepository<RequestValuationForm, int> _requestValuationFormRepo;
//        private readonly IMapper _mapper;

//        public RequestValuationFormService(IRepository<RequestValuationForm, int> requestValuationFormRepo, IMapper mapper)
//        {
//            _requestValuationFormRepo = requestValuationFormRepo;
//            _mapper = mapper;
//        }

//        public async Task<List<RequestValuationFormModel>> GetAll()
//        {
//            try
//            {
//                var reqValuationForms = await _requestValuationFormRepo.GetAll().ToListAsync();
//                var result = _mapper.Map<List<RequestValuationFormModel>>(reqValuationForms);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        public async Task<StatusCodeResponse<RequestValuationFormModel>> GetRequestValuationFormById(int id)
//        {
//            try
//            {
//                var reqValuationForm = await _requestValuationFormRepo.FindByCondition(r => r.RequestValuationFormID == id && r.Status.ToLower().Trim() == "active").FirstOrDefaultAsync();
//                if (reqValuationForm != null)
//                {
//                    return new StatusCodeResponse<RequestValuationFormModel>()
//                    {
//                        Data = _mapper.Map<RequestValuationFormModel>(reqValuationForm),
//                        StatusCode = HttpStatusCode.OK,
//                        Message = "OK",
//                    };
//                }
//                else
//                {
//                    return new StatusCodeResponse<RequestValuationFormModel>()
//                    {
//                        Data = _mapper.Map<RequestValuationFormModel>(reqValuationForm),
//                        StatusCode = HttpStatusCode.NotFound,
//                        Message = "Cannot find this form",
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                return new StatusCodeResponse<RequestValuationFormModel>()
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    Message = ex.Message,
//                    Data = null,
//                };
//            }
//        }

//        public async Task<StatusCodeResponse<RequestValuationFormModel>> CreateRequestValuationForm(CreateRequestValuationFormReq req)
//        {
//            try
//            {
//                var reqValuationForm = _mapper.Map<RequestValuationForm>(req);
//                reqValuationForm.Status = "Active";
//                var data = await _requestValuationFormRepo.AddAsync(reqValuationForm);
//                if (data != null)
//                {
//                    await _requestValuationFormRepo.SaveChangesAsync();
//                    return new StatusCodeResponse<RequestValuationFormModel>()
//                    {
//                        Data = _mapper.Map<RequestValuationFormModel>(data),
//                        StatusCode = HttpStatusCode.OK,
//                        Message = "OK",
//                    };
//                }
//                else
//                {
//                    return new StatusCodeResponse<RequestValuationFormModel>()
//                    {
//                        Data = _mapper.Map<RequestValuationFormModel>(data),
//                        StatusCode = HttpStatusCode.NotFound,
//                        Message = "Cannot create schedule form",
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                return new StatusCodeResponse<RequestValuationFormModel>()
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    Message = ex.Message,
//                    Data = null,
//                };
//            }
//        }

//        public async Task<StatusCodeResponse<RequestValuationFormModel>> ChangeStatus(int id, string status)
//        {
//            try
//            {
//                var reqValuationForm = await _requestValuationFormRepo.FindByCondition(rvf => rvf.RequestValuationFormID == id).FirstOrDefaultAsync();
//                if (reqValuationForm != null)
//                {
//                    reqValuationForm.Status = status;
//                    var data = _requestValuationFormRepo.Update(reqValuationForm);
//                    await _requestValuationFormRepo.SaveChangesAsync();
//                    return new StatusCodeResponse<RequestValuationFormModel>()
//                    {
//                        Data = _mapper.Map<RequestValuationFormModel>(data),
//                        StatusCode = HttpStatusCode.OK,
//                        Message = "OK",
//                    };
//                }
//                else
//                {
//                    return new StatusCodeResponse<RequestValuationFormModel>()
//                    {
//                        Data = null,
//                        StatusCode = HttpStatusCode.BadRequest,
//                        Message = "Cannot upate",
//                    };
//                }
//            }
//            catch (Exception ex)
//            {
//                return new StatusCodeResponse<RequestValuationFormModel>()
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    Message = ex.Message,
//                    Data = null,
//                };
//            }
//        }
//    }
//}
