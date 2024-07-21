using Business.Services;
using Common.Requests;
using Common.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Common.Responses;
using SWP391_Project.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly PaymentService _paymentService;
        private readonly UserService _userService;
        public OrdersController(OrderService orderService, PaymentService paymentService, UserService userService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("Count")]
        public async Task<IActionResult> CountOrders()
        {
            var result = await _orderService.CountOrders();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
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
        //[Authorize]
        [HttpPost("Request")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderReq createOrderReq)
        {

            //if (!Request.Headers.TryGetValue("Authorization", out var token))
            //{
            //    return StatusCode(404, "Cannot find user");
            //}
            //token = token.ToString().Split()[1];
            //var currentUser = await _userService.GetUserInToken(token);
            //if (currentUser == null)
            //{
            //    return StatusCode(404, "Cannot find user");
            //}
            var result = await _orderService.CreateOrder(createOrderReq);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpPost("Submit")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderConsult updateOrderConsult)
        {
            var result = await _orderService.UpdateOrder(updateOrderConsult);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpPut("Pay/Id{id}")]
        public async Task<IActionResult> PayOrder([FromBody] string payment, [FromRoute] int id)
        {
            var result = await _orderService.PayOrder(id, payment);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("View/Code{code}")]
        public async Task<IActionResult> ViewOrderByCode([FromRoute] string code)
        {
            var result = await _orderService.GetOrderFullInfoByCode(code);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("View/Id{id}")]
        public async Task<IActionResult> ViewOrderById([FromRoute] int id)
        {
            var result = await _orderService.GetOrderFullInfoById(id);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("View/CustomerId{id}")]
        public async Task<IActionResult> ViewOrdersByCustomerId([FromRoute] int id)
        {
            var result = await _orderService.GetOrderInfoByCustomerId(id);
            return StatusCode(result.Status, result.Status != 200 ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("PayOnline/UserId{userid}/OrderId{orderid}")]
        public async Task<IActionResult> PayOrderOnline([FromRoute] int userid, [FromRoute] int orderid)
        {
            var result = await _paymentService.CallAPIPayByUserId(userid, orderid);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("PayOnline")]
        public async Task<IActionResult> ChangeStatusPayOrderOnline([FromBody] VNPayRequestDTO dto)
        {
            var result = await _paymentService.GetInformationPayment(dto);
             return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut("Confirm-Return-Order/{orderId}")]
        public async Task<IActionResult> ConfirmReturnOrder([FromRoute] int orderId)
        {
            var result = await _orderService.ConfirmReturnOrder(orderId);
            return StatusCode(result.Status,result.Data == null ? result.Message : result.Data);
        }        
        
        [AllowAnonymous]
        [HttpPut("Confirm-Seal-Order/{orderId}")]
        public async Task<IActionResult> SealOrder([FromRoute] int orderId)
        {
            var result = await _orderService.SealOrder(orderId);
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }        

        [AllowAnonymous]
        [HttpPut("Confirm-Unseal-Order/{orderId}")]
        public async Task<IActionResult> UnSealOrder([FromRoute] int orderId)
        {
            var result = await _orderService.UnSealOrder(orderId);
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
