using Microsoft.AspNetCore.Mvc;
using TestServer.Model;

namespace TestServer.Controllers;

[ApiController]
[Route("[controller]")]
public class NumberController(DataBaseContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Number>> Get()
    {
        return Ok(context.Numbers);
    }

    [HttpPost]
    public IActionResult Post(int number)
    {
        context.Numbers.Add(new Number { Value = number });

        context.SaveChanges();

        return Ok();
    }

    [HttpDelete]

    public IActionResult Delete(long id)
    {
        var number = context.Numbers.FirstOrDefault(n => n.Id == id);

        if (number == null)
            return NotFound();

        context.Numbers.Remove(number);

        context.SaveChanges();

        return Ok();
    }
}
