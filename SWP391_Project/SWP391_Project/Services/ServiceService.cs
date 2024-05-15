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
    public class ServiceService
    {
        private readonly IRepository<Service, int> _serviceRepo;
        private readonly IMapper _mapper;

        public ServiceService(IRepository<Service, int> serviceRepo, IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _mapper = mapper;
        }

        public async Task<StatusCodeResponse<List<ServiceModel>>> GetAllActiveService()
        {
            try
            {
                var services = await _serviceRepo.GetAll().Where(s => s.Status.ToLower().Trim() == "active").ToListAsync();
                if (services.Any())
                {
                    return new StatusCodeResponse<List<ServiceModel>>()
                    {
                        Data = _mapper.Map<List<ServiceModel>>(services),
                        StatusCode = HttpStatusCode.OK,
                        Message = "OK",
                    };
                }
                else
                {
                    return new StatusCodeResponse<List<ServiceModel>>()
                    {
                        Data = _mapper.Map<List<ServiceModel>>(services),
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "No schedule form available",
                    };
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResponse<List<ServiceModel>>()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = null,
                };
            }
        }

        public async Task<StatusCodeResponse<ServiceModel>> GetServiceById(int id)
        {
            try
            {
                var service = await _serviceRepo.FindByCondition(s => s.ServiceID == id && s.Status.ToLower().Trim() == "active").FirstOrDefaultAsync();
                if (service is null)
                {
                    return new StatusCodeResponse<ServiceModel>()
                    {
                        Data = _mapper.Map<ServiceModel>(service),
                        StatusCode = HttpStatusCode.OK,
                        Message = "OK",
                    };
                }
                else
                {
                    return new StatusCodeResponse<ServiceModel>()
                    {
                        Data = _mapper.Map<ServiceModel>(service),
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "No schedule form available",
                    };
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResponse<ServiceModel>()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = null,
                };
            }
        }

        public async Task<StatusCodeResponse<ServiceModel>> CreateService(CreateServiceReq req)
        {
            try
            {
                var service = await _serviceRepo.AddAsync(new Service
                {
                    Name = req.Name,
                    Description = req.Description,
                    Price = req.Price,
                });
                if (service is null)
                {
                    return new StatusCodeResponse<ServiceModel>()
                    {
                        Data = _mapper.Map<ServiceModel>(service),
                        StatusCode = HttpStatusCode.OK,
                        Message = "OK",
                    };
                }
                else
                {
                    return new StatusCodeResponse<ServiceModel>()
                    {
                        Data = _mapper.Map<ServiceModel>(service),
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Cannot create service",
                    };
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResponse<ServiceModel>()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = null,
                };
            }
        }

        public async Task<StatusCodeResponse<ServiceModel>> UpdateService(int id, CreateServiceReq req)
        {
            try
            {
                var service = await _serviceRepo.FindByCondition(rvf => rvf.ServiceID == id).FirstOrDefaultAsync();
                if (service != null)
                {
                    service.Name = req.Name;
                    service.Description = req.Description;
                    service.Price = req.Price;
                    var data = _serviceRepo.Update(service);
                    await _serviceRepo.SaveChangesAsync();
                    return new StatusCodeResponse<ServiceModel>()
                    {
                        Data = _mapper.Map<ServiceModel>(data),
                        StatusCode = HttpStatusCode.OK,
                        Message = "OK",
                    };
                }
                else
                {
                    return new StatusCodeResponse<ServiceModel>()
                    {
                        Data = null,
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Cannot upate",
                    };
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResponse<ServiceModel>()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = null,
                };
            }
        }

        public async Task<StatusCodeResponse<ServiceModel>> ChangeStatus(int id, string status)
        {
            try
            {
                var service = await _serviceRepo.FindByCondition(rvf => rvf.ServiceID == id).FirstOrDefaultAsync();
                if (service != null)
                {
                    service.Status = status;
                    var data = _serviceRepo.Update(service);
                    await _serviceRepo.SaveChangesAsync();
                    return new StatusCodeResponse<ServiceModel>()
                    {
                        Data = _mapper.Map<ServiceModel>(data),
                        StatusCode = HttpStatusCode.OK,
                        Message = "OK",
                    };
                }
                else
                {
                    return new StatusCodeResponse<ServiceModel>()
                    {
                        Data = null,
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Cannot upate",
                    };
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResponse<ServiceModel>()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = null,
                };
            }
        }
    }
}
