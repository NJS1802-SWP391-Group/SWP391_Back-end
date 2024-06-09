using AutoMapper;
using Business.Constants;
using Common.DTOs;
using Common.Enums;
using Common.Requests;
using Common.Responses;
using Data.Helpers;
using Data.Repositories;
using SWP391_Project.Domain.DiavanEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IOrderDetailService
    {
        public Task<IServiceResult> GetAssigningOrderDetails();
        public Task<IServiceResult> GetOrderDetailsByValuStaff(int staffId);
        public Task<IServiceResult> GetCompletedOrderDetails();
        public Task<IServiceResult> AssignStaffToOrderDetail(AssignStaffReq req);
        Task<IServiceResult> AddOrderDetail(int orderId, OrderDetailCreate item);
        Task<IServiceResult> DeleteOrderDetail(int orderDetailId);
        Task<IServiceResult> UpdateOrderDetail(UpdateOrderDetail orderDetailUpdate);
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

        public async Task<IServiceResult> GetAssigningOrderDetails()
        {
            try
            {
                var results = await _unitOfWork.OrderDetailRepository.GetOrderDetailsWithOrderAndServiceAndResultAndValuationStaff(ValuationDetailStatusEnum.Assigning.ToString());
                var rs = _mapper.Map<List<OrderDetailGeneralResponse>>(results);
                return new ServiceResult(200, "Get order details", rs);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetCompletedOrderDetails()
        {
            try
            {
                var results = await _unitOfWork.OrderDetailRepository.GetCompletedOrderDetails(ValuationDetailStatusEnum.Completed.ToString());
                var rs = _mapper.Map<List<GetDoneOrderDetailsResponse>>(results);
                return new ServiceResult(200, "Get done order details", rs);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetOrderDetailsByValuStaff(int staffId)
        {
            try
            {
                var results = await _unitOfWork.OrderDetailRepository.GetOrderDetailsByValuStaff(staffId, ValuationDetailStatusEnum.Valuating.ToString());
                var rs = _mapper.Map<List<StaffOrderDetailsResponse>>(results);
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
                orderDetail.Status = ValuationDetailStatusEnum.Valuating.ToString();
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
        public async Task<IServiceResult> AddOrderDetail(int orderId, OrderDetailCreate item)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId);
                if (order == null) throw new Exception("Can not found Order");
                var detail = _mapper.Map<OrderDetail>(item);
                detail.Price = (await _unitOfWork.ServiceDetailRepository.GetDetailByServiceIdAndLengthAsync(item.ServiceId, item.EstimateLength)).price;
                detail.Code = GenerateCode.OrderDetailCode(orderId);
                detail.OrderId = orderId;
                detail.Status = ValuationDetailStatusEnum.Assigning.ToString();
                await _unitOfWork.OrderDetailRepository.CreateAsync(detail);
                if (order.Quantity == null || order.Quantity == 0) order.Quantity = 0;
                order.Quantity = order.Quantity + 1;
                if (order.TotalPay == null || order.TotalPay == 0) order.TotalPay = 0;
                order.TotalPay = order.TotalPay + detail.Price;
                await _unitOfWork.OrderRepository.UpdateAsync(order);
                var obj = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);
                var result = _mapper.Map<ViewOrderResult>(obj);
                return new ServiceResult(200, "Successful", result);
            }
            catch(Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<IServiceResult> DeleteOrderDetail(int orderdetailId)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(orderdetailId);
                if (orderDetail == null) throw new Exception("Can not found OrderDetail");
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderDetail.OrderId);
                if (order == null) throw new Exception("Can not found Order");
                var flag= _unitOfWork.OrderDetailRepository.Remove(orderDetail);
                if (flag)
                {
                    order.TotalPay = order.TotalPay - orderDetail.Price;
                    order.Quantity  = order.Quantity - 1;
                    _unitOfWork.OrderRepository.Update(order);
                    var obj = await _unitOfWork.OrderRepository.GetOrderByIdAsync(order.OrderID);
                    var result = _mapper.Map<ViewOrderResult>(obj);
                    return new ServiceResult(200, "Successful", result);
                }
                throw new Exception("Can not delete orderDetail");

            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<IServiceResult> UpdateOrderDetail(UpdateOrderDetail orderDetailUpdate)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(orderDetailUpdate.OrderDetailId);
                if (orderDetail == null) throw new Exception("Can not found OrderDetail");
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderDetail.OrderId);
                if (order == null) throw new Exception("Can not found Order");
                orderDetail.ServiceId = orderDetailUpdate.ServiceId;
                order.TotalPay = order.TotalPay - orderDetail.Price;
                orderDetail.EstimateLength = orderDetailUpdate.EstimateLength;
                orderDetail.Price =(await _unitOfWork.ServiceDetailRepository.GetDetailByServiceIdAndLengthAsync(orderDetailUpdate.ServiceId, orderDetailUpdate.EstimateLength)).price;
                order.TotalPay = order.TotalPay + orderDetail.Price;
                _unitOfWork.OrderDetailRepository.Update(orderDetail);
                _unitOfWork.OrderRepository.Update(order);
                var obj = await _unitOfWork.OrderRepository.GetOrderByIdAsync(order.OrderID);
                var result = _mapper.Map<ViewOrderResult>(obj);
                return new ServiceResult(200, "Successful", result);

            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
