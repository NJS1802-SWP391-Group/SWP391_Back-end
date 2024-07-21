using AutoMapper;
using Business.Constants;
using Common.Enums;
using Common.Requests;
using Common.Responses;
using Data.DiavanModels;
using Data.Helpers;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using OpenQA.Selenium.DevTools.V123.CSS;
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

        public async Task<ServiceResult> CountOrders()
        {
            try
            {
                var count = await _unitOfWork.OrderRepository.CountOrders();
                return new ServiceResult(200, "Count orders", count);
            }
            catch (Exception ex)
            {
                return new ServiceResult(-1, ex.Message);
            }

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
                obj.Time = createOrderReq.Time;
                var reqOrder = await _unitOfWork.OrderRepository.CreateAsync(obj);
                var flag = await _unitOfWork.OrderRepository.GetOrderInforById(reqOrder.OrderId);
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
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(UpdateOrder.OrderID);
                _mapper.Map(UpdateOrder, order);
                order.Time = DateTimeHelper.ParseDate(UpdateOrder.Time);
                if (order.TotalPay == null || order.TotalPay == 0) order.TotalPay = 0;
                foreach (var item in order.OrderDetails)
                {
                    item.Price = (await _unitOfWork.ServiceDetailRepository.GetDetailByServiceIdAndLengthAsync(item.ServiceDetailId, item.EstimateLength)).price;
                    if (item.Price <= 0) throw new Exception("Can not find Service");
                    item.OrderId = UpdateOrder.OrderID;
                    item.Code = GenerateCode.OrderDetailCode(UpdateOrder.OrderID);
                    item.Status = ValuationDetailStatusEnum.Pending.ToString();
                    await _unitOfWork.OrderDetailRepository.CreateAsync(item);
                    order.TotalPay = order.TotalPay + item.Price;
                }
                order.Quantity = order.OrderDetails.Count();
                order.Status = OrderStatusEnum.Received.ToString();
                order.ReceiveDay = DateTime.Now;
                _unitOfWork.OrderRepository.Update(order);
                await _unitOfWork.OrderRepository.SaveAsync();
                var obj = await _unitOfWork.OrderRepository.GetOrderByIdAsync(UpdateOrder.OrderID);
                var result = _mapper.Map<ViewOrderResult>(obj);
                return new ServiceResult(200, "Successful", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);

            }
        }
        public async Task<ServiceResult> PayOrder(int id, string payment)
        {
            try
            {
                if (payment == null || payment == "") { throw new Exception("Payment can not null"); }
                var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(id);
                if (order == null) { throw new Exception("Can't not find this Order"); }
                if (order.TotalPay == 0 || order.TotalPay == null) { throw new Exception("The total pay can not be Zero"); }
                if (order.StatusPayment == null || order.StatusPayment.ToLower() != PaymentStatusEnum.successful.ToString())
                {
                    order.StatusPayment = PaymentStatusEnum.successful.ToString();
                    order.Payment = payment.ToLower();
                }
                //else 
                //{ throw new Exception("Fail. This transaction has been settled"); }
                foreach (var item in order.OrderDetails) { item.Status = ValuationDetailStatusEnum.Assigning.ToString();}
                order.Status = OrderStatusEnum.Processing.ToString();
                var updateOrder = await _unitOfWork.OrderRepository.UpdateAsync(order);
                var obj = await _unitOfWork.OrderRepository.GetOrderByIdAsync(order.OrderId);
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
        public async Task<IServiceResult> GetOrderFullInfoById(int id)
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

        public async Task<IServiceResult> GetOrderByIdIncludeCustomer(int orderId)
        {
            try
            {
                var obj = await _unitOfWork.OrderRepository.GetOrderInforById(orderId);
                if(obj == null) { throw new Exception("Not Found Order"); }
                if(obj.Customer == null) { throw new Exception("Not Found Customer"); }
                var orderDetails = await _unitOfWork.OrderDetailRepository.GetDetailByOrderId(obj.OrderId);
                if (!orderDetails.Any()) { throw new Exception("Not Found OrderDetail"); }
                var list = new List<ViewOrderDetailModel>();
                foreach (var item in orderDetails)
                {
                    if (item.AssigningOrderDetails == null) { throw new Exception("Do not find Result"); }
                    if (item.ServiceDetail == null) { throw new Exception("Do not find Service"); }
                    list.Add(new ViewOrderDetailModel
                    {
                        Code = item.Code,
                        EstimateLength = item.EstimateLength,
                        OrderDetailId = item.OrderDetailId,
                        Price = 0,
                        ServiceName = null,
                        ServicePrice = item.Price = (await _unitOfWork.ServiceDetailRepository.GetDetailByServiceIdAndLengthAsync(item.ServiceDetailId, item.EstimateLength)).price,
                        Status = item.Status,
                    }) ;
                }
                if (obj == null) throw new Exception("User don't have any order");
                var result = new GetOrderToSendMail
                {
                    OrderID = obj.OrderId,
                    FirstName = obj.Customer.FirstName,
                    LastName = obj.Customer.LastName,
                    Code = obj.Code,
                    CustomerId = obj.CustomerId,
                    Quantity = (int)obj.Quantity,
                    Time = obj.Time,
                    Status = obj.Status,
                    TotalPay = (double)obj.TotalPay,
                    Payment = obj.Payment,
                    StatusPayment = obj.StatusPayment,
                    CompleteDate = (DateTime)obj.CompleteDate,
                    DetailValuations = list
                };
                return new ServiceResult(200, "Successful", result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
        public async Task<IServiceResult> GetOrderToSendMail(int orderId)
        {
            try
            {

                var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);
                if (order == null) { throw new Exception("Not Found Order"); }
                var result = _mapper.Map<GetOrderToSendMail>(order);
                foreach (var item in result.DetailValuations)
                {
                    var obj = await _unitOfWork.ResultRepository.GetByOrderDetailIdAsync(orderId);
                    if (obj == null)
                    { item.Price = 0; }//sau nay validate
                    else
                        item.Price = obj.DiamondValue;
                }
                return new ServiceResult(200, "Infomation", result);


            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> ConfirmReturnOrder(int orderId)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId);
                if (order.Status != OrderStatusEnum.Completed.ToString())
                {
                    return new ServiceResult(400, "Order is incompleted");
                }

                order.Status = OrderStatusEnum.Returned.ToString();

                var rs = await _unitOfWork.OrderRepository.UpdateAsync(order);

                if (rs < 1)
                {
                    return new ServiceResult(400, "Cannot update");
                }

                return new ServiceResult(200, "Returned successfully");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> SealOrder(int orderId)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId);
                if (order.Status != OrderStatusEnum.Completed.ToString())
                {
                    return new ServiceResult(400, "Order is incompleted");
                }
                if (order.ExpireDate <= DateTime.Now)
                {
                    return new ServiceResult(400, "Order is still not expired");
                }

                order.Status = OrderStatusEnum.Sealed.ToString();

                var rs = await _unitOfWork.OrderRepository.UpdateAsync(order);

                if (rs < 1)
                {
                    return new ServiceResult(400, "Cannot update");
                }

                return new ServiceResult(200, "Sealed successfully");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> UnSealOrder(int orderId)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId);
                if (order.Status != OrderStatusEnum.Sealed.ToString())
                {
                    return new ServiceResult(400, "Order is not sealed");
                }

                order.Status = OrderStatusEnum.Completed.ToString();

                var rs = await _unitOfWork.OrderRepository.UpdateAsync(order);

                if (rs < 1)
                {
                    return new ServiceResult(400, "Cannot update");
                }

                return new ServiceResult(200, "UnSealed successfully");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }


}
