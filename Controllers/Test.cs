using doit.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace doit.Controllers;
[ApiController]
[Route("api/v1/test-middleware/[controller]")]
public class Test : Controller
{
    [HttpGet("notfound")]
    public IActionResult GetNotFound()
    {
        throw new NotFoundException("This is a not found exception.");
    }

    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        throw new BadRequestException("This is a bad request exception.");
    }

    [HttpGet("servererror")]
    public IActionResult GetServerError()
    {
        throw new Exception("This is a server error exception.");
    }
}