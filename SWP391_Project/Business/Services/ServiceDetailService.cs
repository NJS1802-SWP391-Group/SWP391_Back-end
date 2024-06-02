using AutoMapper;
using Business.Constants;
using Common.Requests;
using Common.Responses;
using Data.Repositories;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SWP391_Project.Common.Requests;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IServiceDetailService
    {
        public Task<IServiceResult> GetAll();
        public Task<IServiceResult> GetAllActive();
        public Task<IServiceResult> GetById(int id);
        public Task<IServiceResult> Create(CreateServiceDetailReq req);
        public Task<IServiceResult> Update(int id, UpdateServiceDetailReq req);
        public Task<IServiceResult> ChangeStatus(int id, ChangeStatusReq req);
        public Task<IServiceResult> GetPriceByServiceAndLength(int serviceID, double length);
    }

    public class ServiceDetailService : IServiceDetailService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceDetailService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IServiceResult> GetAll()
        {
            try
            {
                var services = await _unitOfWork.ServiceDetailRepository.GetAllAsync();
                var rs = _mapper.Map<List<ServiceDetailModel>>(services);
                return new ServiceResult(200, "Get all active service details", rs);
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
                var services = await _unitOfWork.ServiceDetailRepository.GetAllActiveAsync();
                var rs = _mapper.Map<List<ServiceDetailModel>>(services);
                if (services.Any())
                {
                    return new ServiceResult(200, "Get all active service details", rs);
                }
                else
                {
                    return new ServiceResult(404, "No active service details");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetById(int id)
        {
            try
            {
                var service = await _unitOfWork.ServiceDetailRepository.GetByIdAsync(id);
                var rs = _mapper.Map<ServiceDetailModel>(service);
                if (service is null)
                {
                    return new ServiceResult(404, "Cannot find service detail");
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

        public async Task<IServiceResult> Create(CreateServiceDetailReq req)
        {
            try
            {
                var rs = await _unitOfWork.ServiceDetailRepository.CreateAsync(new ServiceDetail
                {
                    MinRange = req.MinRange,
                    MaxRange = req.MaxRange,
                    ExtraPricePerMM = req.ExtraPricePerMM,
                    Price = req.Price,
                    Status = "Active",
                    Code = req.Code,
                    ServiceID = req.ServiceID,
                });
                if (rs != null)
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

        public async Task<IServiceResult> Update(int id, UpdateServiceDetailReq req)
        {
            try
            {
                var service = await _unitOfWork.ServiceDetailRepository.GetByIdAsync(id);
                if (service != null)
                {
                    service.MinRange = req.MinRange;
                    service.MaxRange = req.MaxRange;
                    service.Price = req.Price;
                    service.ExtraPricePerMM = req.ExtraPricePerMM;
                    
                    var rs = await _unitOfWork.ServiceDetailRepository.UpdateAsync(service);
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
                    return new ServiceResult(404, "Cannot find service detail");
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
                var service = await _unitOfWork.ServiceDetailRepository.GetByIdAsync(id);
                if (service != null)
                {
                    service.Status = req.Status;
                    var rs = await _unitOfWork.ServiceDetailRepository.UpdateAsync(service);
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
        public async Task<IServiceResult> GetPriceByServiceAndLength(int serviceID, double length)
        {
            try
            {
                var (detail, price) = await _unitOfWork.ServiceDetailRepository.GetDetailByServiceIdAndLengthAsync(serviceID, length);
                if (detail is null)
                {
                    return new ServiceResult(404, "Cannot find service detail");
                }
                var rs = new GetServiceDetailPriceResponse
                {
                    Price = price,
                    ServiceDetailID = detail.ServiceDetailID,
                };
                if (rs.Price <= 0)
                {
                    return new ServiceResult(404, "Cannot find price");
                }
                else
                {
                    return new ServiceResult(200, "Get price by service and length", rs);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
