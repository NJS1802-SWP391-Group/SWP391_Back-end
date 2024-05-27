using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Common.Requests;
using Business.Services;

namespace SWP391_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [AllowAnonymous]
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _serviceService.GetAll();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-All-Active-Service")]
        public async Task<IActionResult> GetAllActiveService()
        {
            var result = await _serviceService.GetAllActive();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-Service-By-Id/{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            if (id <= 0) 
            {
                return StatusCode(500, "Invalid ID");
            }
            var result = await _serviceService.GetServiceById(id);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPost("Create-Service")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceReq req)
        {
            var result = await _serviceService.CreateService(req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Update-Service/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] CreateServiceReq req)
        {
            if (id <= 0)
            {
                return StatusCode(500, "Invalid ID");
            }
            var result = await _serviceService.UpdateService(id, req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Change-Status/{id}")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeStatusReq req)
        {
            if (id <= 0)
            {
                return StatusCode(500, "Invalid ID");
            }
            var result = await _serviceService.ChangeStatus(id, req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
