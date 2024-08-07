﻿using Business.Services;
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
        [HttpGet("Get-Assigning-Order-Details")]
        public async Task<IActionResult> GetAssigningOrderDetails()
        {
            var result = await _orderDetailService.GetAssigningOrderDetails();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-Order-Details-By-Valuating-Staff/{staffId}")]
        public async Task<IActionResult> GetOrderDetailsByValuStaff([FromRoute] int staffId)
        {
            var result = await _orderDetailService.GetOrderDetailsByValuStaff(staffId);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-Completed-Order-Details")]
        public async Task<IActionResult> GetCompletedOrderDetails()
        {
            var result = await _orderDetailService.GetCompletedOrderDetails();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Assign-Staff-To-Order-Detail")]
        public async Task<IActionResult> AssignStaffToOrderDetail([FromBody] AssignStaffReq req)
        {
            if (req.OrderDetailID <= 0 || req.ValuationStaffID <= 0)
            {
                return StatusCode(500, "Invalid id");
            }
            var result = await _orderDetailService.AssignStaffToOrderDetail(req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Complete-Valuate/{orderDetailId}")]
        public async Task<IActionResult> ValuaStaffCompleteValuate([FromRoute] int orderDetailId)
        {
            if (orderDetailId <= 0)
            {
                return StatusCode(500, "Invalid id");
            }
            var result = await _orderDetailService.ValuaStaffCompleteValuate(orderDetailId);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPost("Create/OrderId{orderid}")]
        public async Task<IActionResult> CreateOrderDetail([FromRoute] int orderid, [FromBody] OrderDetailCreate orderDetailCreate)
        {
            var result = await _orderDetailService.AddOrderDetail(orderid, orderDetailCreate);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpDelete("Delete/OrderDetailId{orderDetailid}")]
        public async Task<IActionResult> DeleteOrderDetail([FromRoute] int orderDetailid)
        {
            var result = await _orderDetailService.DeleteOrderDetail(orderDetailid);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOrderDetail([FromBody]UpdateOrderDetail updateOrderDetail)
        {
            if (updateOrderDetail.ServiceId <= 0)
            {
                return StatusCode(500, "Invalid ID");
            }
            if (updateOrderDetail.EstimateLength <= 0)
            {
                return StatusCode(500, "Invalid length");
            }
            var result = await _orderDetailService.UpdateOrderDetail(updateOrderDetail);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Approve-Valuate/{orderDetailId}")]
        public async Task<IActionResult> ManagerApproveValuate([FromRoute] int orderDetailId)
        {
            if (orderDetailId <= 0)
            {
                return StatusCode(400, "Invalid id");
            }
            var result = await _orderDetailService.ManagerApproveOrderDetails(orderDetailId);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Reject-Valuate/{orderDetailId}")]
        public async Task<IActionResult> ManagerRejectValuate([FromRoute] int orderDetailId)
        {
            if (orderDetailId <= 0)
            {
                return StatusCode(400, "Invalid id");
            }
            var result = await _orderDetailService.ManagerRejectOrderDetails(orderDetailId);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

    }
}
