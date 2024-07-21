using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP391_Project.Common.Requests;
using SWP391_Project.Common.Responses;
using SWP391_Project.Common;
using SWP391_Project.Services;
using System.Net;
using SWP391_Project.Dtos;
using Business.Services;

namespace API.Controllers
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
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("count-accounts")]
        public async Task<IActionResult> CountAccounts()
        {
            var result = await _userService.CountAccounts();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("count-customers")]
        public async Task<IActionResult> CountCustomers()
        {
            var result = await _userService.CountCustomers();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("count-consulting-staffs")]
        public async Task<IActionResult> CountConsultingStaffs()
        {
            var result = await _userService.CountConsultingStaffs();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("count-valuating-staffs")]
        public async Task<IActionResult> CountValuatingStaffs()
        {
            var result = await _userService.CountValuatingStaffs();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("count-managers")]
        public async Task<IActionResult> CountManagers()
        {
            var result = await _userService.CountManagers();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("count-admins")]
        public async Task<IActionResult> CountAdmins()
        {
            var result = await _userService.CountAdmins();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }

        [AllowAnonymous]
        [HttpGet("Get-All-Active-Valuation-Staff")]
        public async Task<IActionResult> GetAllActiveValuationStaff()
        {
            var result = await _userService.GetAllValuationStaff();
            return StatusCode(result.Status, result.Data == null ? result.Message : result.Data);
        }
    }
}
