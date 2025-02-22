using Microsoft.AspNetCore.Mvc;

namespace Microwave.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public ActionResult HelloWorld() => Ok("Hello World");
    }
}
