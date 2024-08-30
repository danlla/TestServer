using Microsoft.AspNetCore.Mvc;
using TestServer.Model;

namespace TestServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController(DataBaseContext context) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(int), 200)]
    public ActionResult<int> Sum()
    {
        return Ok(Calculator.Sum(context.Numbers));
    }
}
