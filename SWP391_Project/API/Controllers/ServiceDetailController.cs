using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Common.Requests;
using Business.Services;
using Common.Requests;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailController : Controller
    {
        private readonly IServiceDetailService _serviceDetailService;

        public ServiceDetailController(ServiceDetailService serviceDetailService)
        {
            _serviceDetailService = serviceDetailService;
        }

        [AllowAnonymous]
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _serviceDetailService.GetAll();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-All-Active-Service-Detail")]
        public async Task<IActionResult> GetAllActiveService()
        {
            var result = await _serviceDetailService.GetAllActive();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-Service-Detail-By-Id/{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            if (id <= 0)
            {
                return StatusCode(500, "Invalid ID");
            }
            var result = await _serviceDetailService.GetById(id);
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPost("Create-Service-Detail")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceDetailReq req)
        {
            if (req.MinRange < 0 || req.MaxRange < 0)
            {
                return StatusCode(500, "Invalid range");
            }
            if (req.MinRange >= req.MaxRange && req.MaxRange != 0)
            {
                return StatusCode(500, "Invalid range");
            }
            if (req.Price <= 0)
            {
                return StatusCode(500, "Invalid price");
            }
            if (req.MaxRange != 0 && req.ExtraPricePerMM != 0)
            {
                return StatusCode(500, "Invalid extra price");
            }
            if (req.ServiceID <= 0)
            {
                return StatusCode(500, "Invalid service id");
            }
            var result = await _serviceDetailService.Create(req);
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Update-Service-Detail/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServiceDetailReq req)
        {
            if (id <= 0)
            {
                return StatusCode(500, "Invalid ID");
            }
            if (req.MinRange >= req.MaxRange && req.MaxRange != 0)
            {
                return StatusCode(500, "Invalid range");
            }
            if (req.Price <= 0)
            {
                return StatusCode(500, "Invalid price");
            }
            if (req.MaxRange != 0 && req.ExtraPricePerMM > 0)
            {
                return StatusCode(500, "Invalid extra price");
            }
            var result = await _serviceDetailService.Update(id, req);
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Change-Status/{id}")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeStatusReq req)
        {
            if (id <= 0)
            {
                return StatusCode(500, "Invalid ID");
            }
            var result = await _serviceDetailService.ChangeStatus(id, req);
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-Price-By-Service-And-Length/{serviceId}/{length}")]
        public async Task<IActionResult> GetPriceByServiceAndLength(int serviceId, double length)
        {
            if (serviceId <= 0)
            {
                return StatusCode(500, "Invalid ID");
            }
            if (length <= 0)
            {
                return StatusCode(500, "Invalid length");
            }
            var result = await _serviceDetailService.GetPriceByServiceAndLength(serviceId, length);
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
