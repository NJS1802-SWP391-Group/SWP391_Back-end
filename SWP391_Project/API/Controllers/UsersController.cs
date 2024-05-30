using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Common.Requests;
using SWP391_Project.Common.Responses;
using SWP391_Project.Common;
using SWP391_Project.Services;
using System.Net;
using SWP391_Project.Dtos;
using SWP391_Project.Domain.DiavanEntities;

namespace SWP391_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-All-Active-Valuation-Staff")]
        public async Task<IActionResult> GetAllActiveValuationStaff()
        {
            var result = await _userService.GetAllValuationStaff();
            return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
