using AutoMapper;
using Business.Constants;
using Data.DiavanModels;
using Data.Repositories;
using Newtonsoft.Json;
using SWP391_Project.Common.Requests;
using SWP391_Project.DTOs;

namespace Business.Services
{
    public interface IServiceService
    {
        public Task<IServiceResult> GetAll();
        public Task<IServiceResult> GetAllActive();
        public Task<IServiceResult> GetServiceById(int id);
        public Task<IServiceResult> CreateService(CreateServiceReq req);
        public Task<IServiceResult> UpdateService(int id, CreateServiceReq req);
        public Task<IServiceResult> ChangeStatus(int id, ChangeStatusReq req);
    }

    public class ServiceService : IServiceService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RedisManagerment _redisManager;
        public ServiceService(UnitOfWork unitOfWork, IMapper mapper, RedisManagerment redisManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisManager = redisManager;
        }

        public async Task<IServiceResult> GetAll()
        {
            try
            {
                string cacheKey = "ListServices";
                string productListJson = _redisManager.GetData(cacheKey);
                if (productListJson == null || productListJson == "[]")
                {
                    var productList = _unitOfWork.ServiceRepository.GetAll();
                    if (productList != null)
                    {
                        productListJson = JsonConvert.SerializeObject(productList);
                        _redisManager.SetData(cacheKey, productListJson);
                    }
                    var result = _mapper.Map<List<ServiceModel>>(productList);
                    return new ServiceResult(200, "Get all active services from database", result);              
                }
                else
                {
                    var result = _mapper.Map<List<ServiceModel>>(JsonConvert.DeserializeObject<List<ServiceModel>>(productListJson));
                    return new ServiceResult(200, "Get all active services from Redis", result);
                }

            }
            catch (Exception ex)
               {
                    return new ServiceResult(500, ex.Message);
                }
        }

        public async Task<IServiceResult> GetAllActive()
        {
            try
            {
                var services = ((List<ServiceModel>)(await GetAll()).Data).Where(x=>x.Status.ToLower()=="active");              
                if (services.Any())
                {
                    return new ServiceResult(200, "Get all active services", services);
                }
                else
                {
                    return new ServiceResult(404, "No active service");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetServiceById(int id)
        {
            try
            {
                var service = ((List<ServiceModel>)(await GetAll()).Data).FirstOrDefault(x => x.ServiceID ==id);
                var rs = _mapper.Map<ServiceModel>(service);
                if (service is null)
                {
                    return new ServiceResult(404, "Cannot find service");
                }
                else
                {
                    return new ServiceResult(200, "Get service by id", rs);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> CreateService(CreateServiceReq req)
        {
            try
            {
                var rs = await _unitOfWork.ServiceRepository.CreateAsync(new Service
                {
                    Name = req.Name,
                    Description = req.Description,
                    Status = "Active"
                });
                if (rs!=null)
                {
                    _redisManager.DeleteData("ListServices");
                    return new ServiceResult(200, "Create successfully",rs);
                }
                else
                {
                    return new ServiceResult(500, "Create fail");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> UpdateService(int id, CreateServiceReq req)
        {
            try
            {
                var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
                if (service != null)
                {
                    service.Name = req.Name;
                    service.Description = req.Description;
                    var rs = await _unitOfWork.ServiceRepository.UpdateAsync(service);
                    if (rs > 0)
                    {
                        _redisManager.DeleteData("ListServices");
                        return new ServiceResult(200, "Update successfully");
                    }
                    else
                    {
                        return new ServiceResult(500, "Update fail");
                    }
                }
                else
                {
                    return new ServiceResult(404, "Cannot find ervice");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> ChangeStatus(int id, ChangeStatusReq req)
        {
            try
            {
                var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
                if (service != null)
                {
                    service.Status = req.Status;
                    var rs = await _unitOfWork.ServiceRepository.UpdateAsync(service);
                    if (rs > 0)
                    {
                        _redisManager.DeleteData("ListServices");
                        return new ServiceResult(200, "Change status successfully");
                    }
                    else
                    {
                        return new ServiceResult(500, "change status fail");
                    }
                }
                else
                {
                    return new ServiceResult(404, "Cannot find ervice");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
