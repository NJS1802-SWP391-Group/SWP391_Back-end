using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiamondController : ControllerBase
    {
        private readonly DiamondService _diamondService;

        public DiamondController(DiamondService diamondService)
        {
            _diamondService = diamondService;
        }

        [AllowAnonymous]
        [HttpPost("Mirgate-Diamond-List-To-System-Database")]
        public async Task<IActionResult> GetAssigningOrderDetails()
        {
            var result = await _diamondService.MigrateToSystemDbByDate();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
