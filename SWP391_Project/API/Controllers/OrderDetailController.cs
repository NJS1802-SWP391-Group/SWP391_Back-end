using Business.Services;
using Common.Requests;
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

        [AllowAnonymous]
        [HttpPut("Assign-Staff-To-Order-Detail")]
        public async Task<IActionResult> AssignStaffToOrderDetail([FromBody] AssignStaffReq req)
        {
            if (req.OrderDetailID < 0 || req.ValuationStaffID < 0)
            {
                return StatusCode(500, "Invalid id");
            }
            var result = await _orderDetailService.AssignStaffToOrderDetail(req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
