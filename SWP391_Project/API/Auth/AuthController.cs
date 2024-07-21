using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SWP391_Project.Dtos.Auth;
using SWP391_Project.Common.Requests;
using SWP391_Project.Common.Responses;
using SWP391_Project.Services;
using API.Auth;
using Domain.Exceptions;
using Common.Requests;

namespace SWP391_Project.API.Auth;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IdentityService _identityService;
    private readonly UserService _userService;

    public AuthController(IdentityService identityService, UserService userService)
    {
        _identityService = identityService;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Signup([FromBody] SignupRequest req)
    {
        var result = await _identityService.Signup(req);
        return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> SignupForSystem([FromBody] SignupForSystemRequest req)
    {
        var result = await _identityService.SignupForSystem(req);
        return StatusCode((int)result.Status, result.Data == null ? result.Message : result.Data);
    }

    [AllowAnonymous]
    [HttpPost("login-as-customer")]
    public IActionResult LoginAsCustomer([FromBody] LoginRequest req)
    {
        var loginResult = _identityService.LoginAsCustomer(req.Username, req.Password);
        if (!loginResult.Authenticated)
        {
            var result = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Username or password is invalid"));
            return BadRequest(result);
        }

        var handler = new JwtSecurityTokenHandler();
        var res = new LoginResponse
        {
            RoleName = loginResult.RoleName,
            AccessToken = handler.WriteToken(loginResult.Token),
            CustomerId = loginResult.CustomerId,
        };
        return Ok(ApiResult<LoginResponse>.Succeed(res));
    }

    [AllowAnonymous]
    [HttpPost("login-as-system")]
    public IActionResult LoginAsSystem([FromBody] LoginRequest req)
    {
        var loginResult = _identityService.LoginAsSystem(req.Username, req.Password);
        if (!loginResult.Authenticated)
        {
            var result = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Username or password is invalid"));
            return BadRequest(result);
        }

        var handler = new JwtSecurityTokenHandler();
        var res = new LoginResponse
        {
            RoleName = loginResult.RoleName,
            AccessToken = handler.WriteToken(loginResult.Token),
            CustomerId = loginResult.CustomerId,
        };
        return Ok(ApiResult<LoginResponse>.Succeed(res));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> CheckToken()
    {
       if (!Request.Headers.TryGetValue("Authorization", out var token))
        {
            return StatusCode(404, "Cannot find user");
        }
        token = token.ToString().Split()[1];
        var currentUser = await _userService.GetUserInToken(token);
        if (currentUser == null)
        {
            return StatusCode(404, "Cannot find user");
        }
        // Here goes your token validation logic
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new BadRequestException("Authorization header is missing or invalid.");
        }
        // Decode the JWT token
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        // Check if the token is expired
        if (jwtToken.ValidTo < DateTime.UtcNow)
        {
            throw new BadRequestException("Token has expired.");
        }

        string email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

        var user = await _userService.GetUserByUserName(email);
        var customer = await _userService.GetCustomerById(currentUser.CustomerId);
        if (user.Data == null)
        {
            return BadRequest("username is in valid");
        }

        // If token is valid, return success response
        return Ok(ApiResult<CheckTokenResponse>.Succeed(new CheckTokenResponse
        {
            User = user.Data,
            Customer = customer
        }));
    }
}