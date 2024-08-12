using doit.Models.DTOs;
using doit.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace doit.Controllers;


[ApiController]
[Route("api/v1/admin/[controller]")]
public class AdminController : Controller
{
    private readonly IAdminAuth _adminAuth;
    private readonly IAdminHelperMethods _adminHelperMethods;
    private readonly IToken _token;
    private readonly IMessage _message;
    
    public AdminController(IAdminAuth adminAuth, IAdminHelperMethods adminHelperMethods, IToken token, IMessage message)
    {
        _adminAuth = adminAuth;
        _adminHelperMethods = adminHelperMethods;
        _token = token;
        _message = message;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AdminDto adminDto)
    {
        var token = await _adminAuth.AuthenticateAdmin(adminDto);
        return Ok(new { token = "Bearer " + token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AdminDto adminDto)
    {
        var result = await _adminAuth.RegisterAdmin(adminDto);
        return Ok(new {result});
    }
    
    // get all messages
    // but only admin can access this route
    [HttpGet("messages")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetMessages([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var messages = await _message.GetMessagesAsync(pageNumber, pageSize);
        return Ok(messages);
    }
    
    // validate token
    [HttpPost("validate")]
    public async Task<IActionResult> ValidateToken()
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var result = _token.ValidateToken(token);
        return Ok(new { result });
    }
        
}