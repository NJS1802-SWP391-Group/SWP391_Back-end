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
        [HttpPost("Request")]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderReq createOrderReq)
        {
            var result = await _orderService.CreateOrder(createOrderReq);
            return StatusCode(result.Status,result.Status != 200?result.Message:result.Data);
        }
        [AllowAnonymous]
        [HttpPost("Submit")]
        public async Task<IActionResult> UpdateOrder([FromBody]UpdateOrderConsult updateOrderConsult)
        {
            var result = await _orderService.UpdateOrder(updateOrderConsult);
            return StatusCode(result.Status, result.Status!=200?result.Message:result.Data);
        }
        [AllowAnonymous]
        [HttpPut("Pay/Id={id}/Payment={payment}")]
        public async Task<IActionResult> PayOrder([FromRoute] string payment , [FromBody] string status, [FromRoute] int id)
        {
            var result = await _orderService.PayOrder(id,payment,status);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("View/Code={code}")]
        public async Task<IActionResult> ViewOrderByCode([FromRoute] string code)
        {
            var result = await _orderService.GetOrderFullInfoByCode(code);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("View/Id={id}")]
        public async Task<IActionResult> ViewOrderById([FromRoute] int id)
        {
            var result = await _orderService.GetOrderFullInfoById(id);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("View/CustomerId={id}")]
        public async Task<IActionResult> ViewOrdersByCustomerId([FromRoute] int id)
        {
            var result = await _orderService.GetOrderInfoByCustomerId(id);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
    }
}
