using AutoMapper;
using Business.Constants;
using Common.DTOs;
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

    }
}
