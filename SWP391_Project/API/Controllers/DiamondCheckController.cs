using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiamondCheckController : Controller
    {
        private readonly DiamondCheckService _diamondCheckService;
        public DiamondCheckController(DiamondCheckService diamondCheckService)
        {
            _diamondCheckService = diamondCheckService;
        }

        [AllowAnonymous]
        [HttpGet("Check/{id}")]
        public async Task<IActionResult> CheckDiamond([FromRoute]string id)
        {
            var result = await _diamondCheckService.GetInfomationByCertificateId(id);
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
