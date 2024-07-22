using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IDashboardService _adminService;
        public AdminController(IDashboardService adminService)
        {
            _adminService = adminService;
        }
        [AllowAnonymous]
        [HttpGet("Order/Quantity")]
        public async Task<IActionResult> GetDashboardOrders()
        {
            var result = await _adminService.OrderDashboard();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
        [AllowAnonymous]
        [HttpGet("Order/Quantity/Payment")]
        public async Task<IActionResult> GetDashboardOrdersPrice()
        {
            var result = await _adminService.OrderDashboardPayment();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
