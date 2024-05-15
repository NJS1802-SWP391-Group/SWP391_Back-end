using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Common.Requests;
using SWP391_Project.Services;

namespace SWP391_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleFormController : Controller
    {
        private readonly ScheduleFormService _scheduleFormService;

        public ScheduleFormController(ScheduleFormService scheduleFormService)
        {
            _scheduleFormService = scheduleFormService;
        }

        [AllowAnonymous]
        [HttpGet("GetAllScheduleForm")]
        public async Task<IActionResult> GetAllScheduleForm()
        {
            var result = await _scheduleFormService.GetAllScheduleForm();
            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpPost("Create-Schedule-Form")]
        public async Task<IActionResult> CreateScheduleForm([FromBody] CreateScheduleFormReq req)
        {
            var result = await _scheduleFormService.CreateScheduleForm(req);
            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
        }
    }
}
