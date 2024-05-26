//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SWP391_Project.Common.Requests;
//using SWP391_Project.Services;

//namespace SWP391_Project.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ScheduleFormController : Controller
//    {
//        private readonly ScheduleFormService _scheduleFormService;

//        public ScheduleFormController(ScheduleFormService scheduleFormService)
//        {
//            _scheduleFormService = scheduleFormService;
//        }

//        [AllowAnonymous]
//        [HttpGet("Get-All-Active-Schedule-Form")]
//        public async Task<IActionResult> GetAllActiveScheduleForm()
//        {
//            var result = await _scheduleFormService.GetAllActiveScheduleForm();
//            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
//        }
        
//        [AllowAnonymous]
//        [HttpGet("Get-Schedule-Form-By-Id/{id}")]
//        public async Task<IActionResult> GetScheduleFormById(int id)
//        {
//            var result = await _scheduleFormService.GetScheduleFormById(id);
//            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
//        }

//        [AllowAnonymous]
//        [HttpPost("Create-Schedule-Form")]
//        public async Task<IActionResult> CreateScheduleForm([FromBody] CreateScheduleFormReq req)
//        {
//            var result = await _scheduleFormService.CreateScheduleForm(req);
//            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
//        }

//        [AllowAnonymous]
//        [HttpPut("Change-Status/{id}")]
//        public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeStatusReq req)
//        {
//            var result = await _scheduleFormService.ChangeStatus(id, req.Status);
//            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
//        }
//    }
//}
