//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SWP391_Project.Common.Requests;
//using SWP391_Project.Common.Responses;
//using SWP391_Project.Common;
//using SWP391_Project.Services;
//using SWP391_Project.Constants;
//using SWP391_Project.Databases.Models;
//using System.Net;
//using SWP391_Project.Dtos;

//namespace SWP391_Project.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : Controller
//    {
//        private readonly UserService _userService;

//        public UsersController(UserService userService)
//        {
//            _userService = userService;
//        }

//        [AllowAnonymous]
//        [HttpGet("GetAllUsers")]
//        public async Task<IActionResult> GetAll()
//        {
//            var res = await _userService.GetAll();
//            if (res is null)
//            {
//                var resultFail = new StatusCodeResponse<List<UserModel>>
//                {
//                    Data = null,
//                    StatusCode = HttpStatusCode.BadRequest,
//                    Message = "Fail"
//                };
//                return StatusCode((int)resultFail.StatusCode, resultFail.Message);
//            }
//            var result = new StatusCodeResponse<List<UserModel>>
//            {
//                Data = res,
//                StatusCode = HttpStatusCode.OK,
//                Message = "Succeed"
//            };
//            return StatusCode((int)result.StatusCode, result.Data);
//        }
//    }
//}
