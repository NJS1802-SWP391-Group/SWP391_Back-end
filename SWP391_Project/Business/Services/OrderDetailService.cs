using AutoMapper;
using Business.Constants;
using Common.DTOs;
using Common.Enums;
using Common.Requests;
using Common.Responses;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IOrderDetailService
    {
        public Task<IServiceResult> GetOrderDetailsWithOrderAndServiceAndResultAndValuationStaff();
        public Task<IServiceResult> AssignStaffToOrderDetail(AssignStaffReq req);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IServiceResult> GetOrderDetailsWithOrderAndServiceAndResultAndValuationStaff()
        {
            try
            {
                var results = await _unitOfWork.OrderDetailRepository.GetOrderDetailsWithOrderAndServiceAndResultAndValuationStaff();
                var rs = _mapper.Map<List<OrderDetailGeneralResponse>>(results);
                return new ServiceResult(200, "Get order details", rs);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult>  AssignStaffToOrderDetail(AssignStaffReq req)
        {
            try
            {
                if (!_unitOfWork.UserRepository.GetById(req.ValuationStaffID).RoleName.Equals(RoleNameEnum.ValuationStaff.ToString()))
                {
                    return new ServiceResult(404, "Cannot find valuation staff");
                }
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAndIsAssigning(req.OrderDetailID, ValuationDetailStatusEnum.Assigning.ToString());
                if (orderDetail == null)
                {
                    return new ServiceResult(404, "Cannot find order detail");
                }
                if (orderDetail.ValuationStaffId != null)
                {
                    return new ServiceResult(500, "Order detail already assigned");
                }
                orderDetail.ValuationStaffId = req.ValuationStaffID;
                var rs = await _unitOfWork.OrderDetailRepository.UpdateAsync(orderDetail);
                if (rs < 1)
                {
                    return new ServiceResult(500, "Cannot assign to order detail");
                }
                return new ServiceResult(200, "Assign completed");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

    }
}
