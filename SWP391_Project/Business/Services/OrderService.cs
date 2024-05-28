using Business.Constants;
using Data.Repositories;
using OpenQA.Selenium.DevTools.V123.CSS;
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
        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResult> GetAllOrders()
        {
           var result = await _unitOfWork.OrderRepository.GetAllAsync();
            if (result != null) { return new ServiceResult(1, "List Order", result); }
            return new ServiceResult(-1,"List Null");
        }
    }
}
