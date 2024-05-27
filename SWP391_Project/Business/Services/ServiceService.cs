using AutoMapper;
using Business.Constants;
using Data.Repositories;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.Common.Requests;

namespace SWP391_Project.Services
{
    public interface IServiceService
    {
        public Task<IServiceResult> GetAll();
        public Task<IServiceResult> GetAllActive();
        public Task<IServiceResult> GetServiceById(int id);
        public Task<IServiceResult> UpdateService(int id, CreateServiceReq req);
        public Task<IServiceResult> ChangeStatus(int id, ChangeStatusReq req);
    }

    public class ServiceService : IServiceService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IServiceResult> GetAll()
        {
            try
            {
                var services = _unitOfWork.ServiceRepository.GetAll();
                return new ServiceResult(200, "Get all active services", services);
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
                var services = _unitOfWork.ServiceRepository.GetAllActive();
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
                var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
                if (service is null)
                {
                    return new ServiceResult(404, "Cannot find service");
                }
                else
                {
                    return new ServiceResult(200, "Get service by id", service);
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
                });
                if (rs > 0)
                {
                    return new ServiceResult(200, "Create successfully");
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
                    service.Name = req.Status;
                    var rs = await _unitOfWork.ServiceRepository.UpdateAsync(service);
                    if (rs > 0)
                    {
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
