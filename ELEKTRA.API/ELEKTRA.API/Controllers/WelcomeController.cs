using ELEKTRA.API.Interfaces;
using ELEKTRA.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ELEKTRA.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WelcomeController : ControllerBase
{
    private readonly IWelcomeService _welcomeService;

    // constructor
    public WelcomeController(IWelcomeService welcomeService)
    {
        _welcomeService = welcomeService;
    }

    [HttpGet(Name = "GetWelcomeMessage")]
    public string Get()
    {
        return _welcomeService.GetWelcomeMessage();
    }

    // to return json, use something like this. What is IActionResult :OOO
    //[HttpGet(Name = "GetWelcomeMessage")]
    //public IActionResult Get()
    //{
    //    var message = _welcomeService.GetWelcomeMessage();
    //    return new JsonResult(new { Message = message });
    //}
}
