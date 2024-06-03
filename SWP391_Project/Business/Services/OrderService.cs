using AutoMapper;
using Business.Constants;
using Common.Enums;
using Common.Requests;
using Common.Responses;
using Data.Helpers;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using OpenQA.Selenium.DevTools.V123.CSS;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class OrderService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResult> GetAllOrders()
        {
            try
            {
                var list = await _unitOfWork.OrderRepository.GetAllOrder();
                if (list != null)
                {
                    var result = _mapper.Map<List<ViewOrderResponse>>(list);
                    return new ServiceResult(1, "List Order", result);
                }
                return new ServiceResult(-1, "List Null");
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }

        }
        public async Task<ServiceResult> CreateOrder(CreateOrderReq createOrderReq)
        {
            try
            {
                var check = await _unitOfWork.CustomerRepository.GetByIdAsync(createOrderReq.CustomerId);
                if (check == null) throw new Exception("Can't not find the customer");
                var obj = _mapper.Map<Order>(createOrderReq);
                obj.Code = GenerateCode.OrderCode();
                obj.Status = OrderStatusEnum.Pending.ToString();
                obj.Time = DateTimeHelper.ParseDate(createOrderReq.Time);
                var reqOrder = await _unitOfWork.OrderRepository.CreateAsync(obj);
                var flag = await _unitOfWork.OrderRepository.GetOrderInforById(reqOrder.OrderID);
                var result = _mapper.Map<ViewOrderResponse>(reqOrder);
                return new ServiceResult(200, "Successful", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<ServiceResult> UpdateOrder(UpdateOrderConsult UpdateOrder)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(UpdateOrder.OrderID);
                _mapper.Map(UpdateOrder, order);
                order.Time = DateTimeHelper.ParseDate(UpdateOrder.Time);
                if (order.TotalPay == null || order.TotalPay == 0) order.TotalPay = 0;
                foreach (var item in order.DetailValuations)
                {
                    item.Price = (await _unitOfWork.ServiceDetailRepository.GetDetailByServiceIdAndLengthAsync(item.ServiceId, item.EstimateLength)).price;
                    if (item.Price <= 0) throw new Exception("Can not find Service");
                    item.OrderId = UpdateOrder.OrderID;
                    item.Code = GenerateCode.OrderDetailCode(UpdateOrder.OrderID);
                    item.Status = ValuationDetailStatusEnum.Assigning.ToString();
                    await _unitOfWork.OrderDetailRepository.CreateAsync(item);
                    order.TotalPay = order.TotalPay + item.Price;
                }
                order.Quantity = order.DetailValuations.Count();
                _unitOfWork.OrderRepository.Update(order);
                await _unitOfWork.OrderRepository.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();
                var obj = await _unitOfWork.OrderRepository.GetOrderByIdAsync(UpdateOrder.OrderID);
                var result = _mapper.Map<ViewOrderResult>(obj);
                return new ServiceResult(200, "Successful", result);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransactionAsync();
                return new ServiceResult(500, ex.Message);

            }
        }
        public async Task<ServiceResult> PayOrder(int id, string payment, string status)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
                order.Payment = payment;
                order.StatusPayment = status;
                order.Status = OrderStatusEnum.Processing.ToString();
                var updateOrder = await _unitOfWork.OrderRepository.UpdateAsync(order);
                var obj = await _unitOfWork.OrderRepository.GetOrderByIdAsync(order.OrderID);
                var result = _mapper.Map<ViewFullInfomaionOrder>(obj);
                return new ServiceResult(200, "Successful", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<ServiceResult> GetOrderFullInfoByCode(string Code)
        {
            try
            {
                var obj = await _unitOfWork.OrderRepository.GetOrderByCode(Code);
                if (obj == null) throw new Exception("Don't have any Order has this code");
                var result = _mapper.Map<ViewFullInfomaionOrder>(obj);
                return new ServiceResult(200, "Successful", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<ServiceResult> GetOrderFullInfoById(int id)
        {
            try
            {
                var obj = await _unitOfWork.OrderRepository.GetOrderByIdAsync(id);
                if (obj == null) throw new Exception("Don't have any Order has this Id");
                var result = _mapper.Map<ViewFullInfomaionOrder>(obj);
                return new ServiceResult(200, "Successful", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<ServiceResult> GetOrderInfoByCustomerId(int id)
        {
            try
            {
                var obj = await _unitOfWork.OrderRepository.GetOrdersByCustomerId(id);
                if (obj == null) throw new Exception("User don't have any order");
                var result = _mapper.Map<List<ViewFullInfomaionOrder>>(obj);
                return new ServiceResult(200, "Successful", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
