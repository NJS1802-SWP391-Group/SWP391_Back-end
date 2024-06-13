using Business.Services;
using Common.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Common.Requests;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : Controller
    {
        private readonly IResultService _resultService;

        public ResultController(ResultService resultService)
        {
            _resultService = resultService;
        }

        [AllowAnonymous]
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _resultService.GetAll();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-All-Active-Result")]
        public async Task<IActionResult> GetAllActiveResult()
        {
            var result = await _resultService.GetAllActive();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-Result-By-Id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return StatusCode(400, "Invalid ID");
            }
            var result = await _resultService.GetById(id);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-Result-By-Order-Detail-Id/{id}")]
        public async Task<IActionResult> GetByOrderDetailId(int id)
        {
            if (id <= 0)
            {
                return StatusCode(400, "Invalid ID");
            }
            var result = await _resultService.GetByOrderDetailId(id);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPost("Create-Result")]
        public async Task<IActionResult> Create([FromBody] CreateResultReq req)
        {
            if (req.DiamondValue < 0)
            {
                return StatusCode(400, "Diamond value should >= 0");
            }
            if (req.OrderDetailId <= 0)
            {
                return StatusCode(400, "Invalid ID");
            }
            var result = await _resultService.Create(req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Update-Result/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateResultReq req)
        {
            if (id <= 0)
            {
                return StatusCode(400, "Invalid ID");
            }
            var result = await _resultService.Update(id, req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPut("Change-Status/{id}")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeStatusReq req)
        {
            if (id <= 0)
            {
                return StatusCode(400, "Invalid ID");
            }
            var result = await _resultService.ChangeStatus(id, req);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
