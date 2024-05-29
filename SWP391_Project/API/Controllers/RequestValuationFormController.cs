﻿//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SWP391_Project.Common;
//using SWP391_Project.Common.Requests;
//using SWP391_Project.Constants;
//using SWP391_Project.Databases.Models;
//using SWP391_Project.Dtos;
//using SWP391_Project.DTOs;
//using SWP391_Project.Services;
//using System.Net;

//namespace SWP391_Project.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RequestValuationFormController : Controller
//    {
//        private readonly RequestValuationFormService _requestValuationFormService;

//        public RequestValuationFormController(RequestValuationFormService requestValuationFormService)
//        {
//            _requestValuationFormService = requestValuationFormService;
//        }

//        [AllowAnonymous]
//        [HttpGet("Get-All-Request-Valuation")]
//        public async Task<IActionResult> GetAll() 
//        {
//            var res = await _requestValuationFormService.GetAll();
//            if(res is null)
//            {
//                var resultFail = new StatusCodeResponse<List<RequestValuationFormModel>>
//                {
//                    Data = null,
//                    StatusCode = HttpStatusCode.BadRequest,
//                    Message = "Fail"
//                };
//                return StatusCode((int)resultFail.StatusCode, resultFail.Message);
//            }
//            var result = new StatusCodeResponse<List<RequestValuationFormModel>>
//            {
//                Data = res,
//                StatusCode = HttpStatusCode.OK,
//                Message = "Succeed"
//            };
//            return StatusCode((int)result.StatusCode, result.Data);
//        }

//        [AllowAnonymous]
//        [HttpGet("Get-Request-Valuation-Form-By-Id")]
//        public async Task<IActionResult> GetRequestValuationFormById(int id)
//        {
//            var result = await _requestValuationFormService.GetRequestValuationFormById(id);
//            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
//        }

//        [AllowAnonymous]
//        [HttpPost("Create-Request-Valuation-Form")]
//        public async Task<IActionResult> CreateRequestValuationForm([FromBody]CreateRequestValuationFormReq req) 
//        {
//            var result = await _requestValuationFormService.CreateRequestValuationForm(req);
//            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
//        }

//        [AllowAnonymous]
//        [HttpPut("Change-Status/{id}")]
//        public async Task<IActionResult> ChangeStatus(int id, [FromBody] ChangeStatusReq req)
//        {
//            var result = await _requestValuationFormService.ChangeStatus(id, req.Status);
//            return StatusCode((int)result.StatusCode, result.Data == null ? result.Message : result.Data);
//        }
//    }
//}