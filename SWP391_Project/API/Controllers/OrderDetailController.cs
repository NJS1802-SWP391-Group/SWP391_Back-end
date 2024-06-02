using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(OrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [AllowAnonymous]
        [HttpGet("Get-Order-Details")]
        public async Task<IActionResult> GetOrderDetails() 
        {
            var result = await _orderDetailService.GetOrderDetailsWithOrderAndServiceAndResultAndValuationStaff();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
