using EndPoint.Site.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shope.Application.Services.User;
using Shope.Common.DTO.Base;
using Shope.Common.DTO.User;

namespace EndPoint.Site.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }
    [HttpGet("GetAllUser")]
    public async Task<IActionResult> GetAllUser()
    {
        var Result = await _service.GetAllUser();
        return Ok(Result);
    }
    [HttpGet("GetUser")]
    [Authorize]
    public async Task<IActionResult> GetUser()
    {
        int id = HttpContext.GetUserId();
        var Result = await _service.GetUser(id);
        return Ok(Result);
    }
    [HttpPost("logup")]
    public async Task<IActionResult> Logup(LogupDto logupDto)
    {
        var Result = await _service.Logup(logupDto);
        return Ok(Result);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var Result = await _service.Login(loginDto);
        return Ok(Result);
    }
}