using AutoMapper;
using Business.Constants;
using Common.DTOs;
using Common.Enums;
using Common.Requests;
using Data.Repositories;
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
    public interface IResultService
    {
        public Task<IServiceResult> GetAll();
        public Task<IServiceResult> GetAllActive();
        public Task<IServiceResult> GetById(int id);
        public Task<IServiceResult> GetByOrderDetailId(int id);
        public Task<IServiceResult> Create(CreateResultReq req);
        public Task<IServiceResult> Update(int id, UpdateResultReq req);
        public Task<IServiceResult> ChangeStatus(int id, ChangeStatusReq req);
    }
    public class ResultService : IResultService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResultService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IServiceResult> GetAll()
        {
            try
            {
                var results = await _unitOfWork.ResultRepository.GetAllAsync();
                var rs = _mapper.Map<List<ResultModel>>(results);
                return new ServiceResult(200, "Get all result", rs);
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
                var results = await _unitOfWork.ResultRepository.GetAllActiveAsync();
                var rs = _mapper.Map<List<ResultModel>>(results);
                if (results.Any())
                {
                    return new ServiceResult(200, "Get all active result", rs);
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
                var service = await _unitOfWork.ResultRepository.GetByIdAsync(id);
                var rs = _mapper.Map<ResultModel>(service);
                if (service is null)
                {
                    return new ServiceResult(404, "Cannot find result");
                }
                else
                {
                    return new ServiceResult(200, "Get result by id", rs);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetByOrderDetailId(int id)
        {
            try
            {
                var service = await _unitOfWork.ResultRepository.GetByOrderDetailIdAsync(id);
                var rs = _mapper.Map<ResultModel>(service);
                if (service is null)
                {
                    return new ServiceResult(404, "Cannot find result");
                }
                else
                {
                    return new ServiceResult(200, "Get result by id", rs);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> Create(CreateResultReq req)
        {
            try
            {
                var orDetail = _unitOfWork.OrderDetailRepository.GetAll().Where(_ => _.OrderDetailId == req.OrderDetailId && _.Status.Equals(ValuationDetailStatusEnum.Valuating.ToString())).FirstOrDefault();

                if (orDetail is null)
                {
                    return new ServiceResult(404, "Cannot find order detail");
                }

                if (orDetail.ResultId != null)
                {
                    return new ServiceResult(400, "Fail");
                }

                var createObj = _mapper.Map<Result>(req);
                var rs = await _unitOfWork.ResultRepository.CreateAsync(createObj);
                
                if (rs != null)
                {
                    orDetail.ResultId = rs.ResultId;
                    var rsUpdate = await _unitOfWork.OrderDetailRepository.UpdateAsync(orDetail);

                    if (rsUpdate < 1)
                    {
                        return new ServiceResult(500, "Create failed");
                    }

                    return new ServiceResult(200, "Create successfully");
                }
                else
                {
                    return new ServiceResult(500, "Create failed");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> Update(int id, UpdateResultReq req)
        {
            try
            {
                var service = await _unitOfWork.ResultRepository.GetByIdAsync(id);
                if (service != null)
                {
                    var updateObj = _mapper.Map(req, service);
                    var rs = await _unitOfWork.ResultRepository.UpdateAsync(updateObj);
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
                var service = await _unitOfWork.ResultRepository.GetByIdAsync(id);
                if (service != null)
                {
                    service.Status = req.Status;
                    var rs = await _unitOfWork.ResultRepository.UpdateAsync(service);
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
