using AutoMapper;
using Business.Constants;
using Common.Enums;
using Common.Responses;
using Data.DiavanModels;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IDashboardService
    {
        Task<IServiceResult> OrderDashboard();
        Task<IServiceResult> OrderDashboardPayment();
        Task<IServiceResult> GetNumberOfServiceUsed();
    }
    public class DashboardService:IDashboardService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;
        public DashboardService(UnitOfWork unitOfWork , IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IServiceResult> OrderDashboard()
        {
            var data = await _unitOfWork.OrderRepository.OrdersDashboard();
            double sum = 0;
            var result = new AdminResponse();
            result.AdminDatas = new List<AdminData>();

            if (data != null && data.Count > 1)
            {
                for (var i = DateTime.Now.Date; i.Date >= data.Min(x => x.Date.Date); i = i.AddDays(-1))
                {
                    if (!data.Any(x => x.Date.Date == i.Date))
                    {
                        data.Add(new AdminData { Date = i.Date, Value = 0 });
                    }
                }

                data = data.OrderBy(c => c.Date).ToList();

                var lastCustomer = data[^1];
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;

                if (penultimateCustomer.Value == 0)
                {
                    result.Trend = 0;
                }
                else
                {
                    result.Trend = trend;
                }
            }

            foreach (var customer in data)
            {

                result.AdminDatas.Add(new AdminData { Date = customer.Date, Value = customer.Value });
                sum += customer.Value;
            }

            result.Total = sum;
            return new ServiceResult(200, "Get order dashboard", result);
        }
        public async Task<IServiceResult> OrderDashboardPayment()
        {
            var data = await _unitOfWork.OrderRepository.OrdersPriceDashboard();
            double sum = 0;
            var result = new AdminResponse();
            result.AdminDatas = new List<AdminData>();

            if (data != null && data.Count > 1)
            {
                for (var i = DateTime.Now.Date; i.Date >= data.Min(x => x.Date.Date); i = i.AddDays(-1))
                {
                    if (!data.Any(x => x.Date.Date == i.Date))
                    {
                        data.Add(new AdminData { Date = i.Date, Value = 0 });
                    }
                }

                data = data.OrderBy(c => c.Date).ToList();

                var lastCustomer = data[^1];
                var penultimateCustomer = data[^2];
                var trend = lastCustomer.Value - penultimateCustomer.Value;

                if (penultimateCustomer.Value == 0)
                {
                    result.Trend = 0;
                }
                else
                {
                    result.Trend = trend;
                }
            }

            foreach (var customer in data)
            {

                result.AdminDatas.Add(new AdminData { Date = customer.Date, Value = customer.Value });
                sum += customer.Value;
            }

            result.Total = sum;
            return new ServiceResult(200, "Get order dashboard", result);
        }

        public async Task<IServiceResult> GetNumberOfServiceUsed()
        {
            try
            {
                var listOrderDetail = await _unitOfWork.OrderDetailRepository.GetOrderDetailIsNotPending(ValuationDetailStatusEnum.Pending.ToString());
                var listServiceInfo = listOrderDetail.GroupBy(_ => _.Service)
                                                    .Select(_ => new
                                                    {
                                                        ServiceID = _.Key.ServiceId,
                                                        ServiceName = _.Key.Name,
                                                        Quantity = _.Count()
                                                    })
                                                    .ToList();

                var rs = new List<ServiceInfoResponse>();
                var allService = _unitOfWork.ServiceRepository.GetAll();

                foreach (var service in allService)
                {
                    var serviceInfo = listServiceInfo.FirstOrDefault(si => si.ServiceID == service.ServiceId);
                    if (serviceInfo != null)
                    {
                        rs.Add(new ServiceInfoResponse
                        {
                            ServiceID = service.ServiceId,
                            ServiceName = service.Name,
                            Quantity = serviceInfo.Quantity
                        });
                    }
                    else
                    {
                        rs.Add(new ServiceInfoResponse
                        {
                            ServiceID = service.ServiceId,
                            ServiceName = service.Name,
                            Quantity = 0
                        });
                    }
                }

                return new ServiceResult(200, "List service info", rs);

            }
            catch(Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
