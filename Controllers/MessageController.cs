using doit.Models.DTOs;
using doit.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace doit.Controllers;

[ApiController]
[Route("api/v1/user/[controller]")]
public class MessageController : Controller
{
    private readonly IMessage _message;
    
    public MessageController(IMessage message)
    {
        _message = message;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateMessage([FromBody] MessageDTO messageDTO)
    {
        var message = await _message.CreateMessageAsync(messageDTO);
        return Ok(new {message});
    }
    
    // add subject to message
            [HttpPost("add-subject")]
            public async Task<IActionResult> AddSubject([FromQuery] int messageId, [FromQuery] string subject)
            {
                var message = await _message.AddSubjectAsync(messageId, subject);
                return Ok(new {message});
            }   
    

    
    
}