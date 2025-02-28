using Microsoft.AspNetCore.Mvc;

namespace ELEKTRA.API.Controllers

[ApiController]
[Route("/api")]
public class CommonController : ControllerBase
{
    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        var timestamp = DateTime.Now.Ticks;

        return Ok(timestamp.AsApiResponse());
    }
}
