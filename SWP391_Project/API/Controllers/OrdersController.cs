using Business.Services;
using Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }
        [AllowAnonymous]
        [HttpGet("All")]
        public async Task<IActionResult> GetAllOrder()
        {
            var result = await _orderService.GetAllOrders();
            if (result.Status == 1) { return StatusCode(200, result.Data); }
            return StatusCode(500, result.Message);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderReq createOrderReq)
        {
            var result = await _orderService.CreateOrder(createOrderReq);
            if (result.Status == 1) { return StatusCode(200, result.Data); }
            return StatusCode(500, result.Message);
        }
    }
}
