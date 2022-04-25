using Microsoft.AspNetCore.Mvc;
using Principal.Filters;

namespace Principal.Controllers
{

    [Route("allo")]
    public class HelloController : Controller
    {
        ILogger<HelloController> _log;

        public HelloController(ILogger<HelloController> log) {
            _log = log;
        }
        

        [HttpGet()]
        [MyFilter]
        [Route("{nom?}")]
        public IActionResult Index(string nom)
        {
            _log.LogError($"Bonjour {nom}");
            return Content($"Bonjour {nom}");
        }

        [HttpGet("test")]
        public IActionResult Test() {
            return Redirect("https://www.google.com");
        }

    }
}
