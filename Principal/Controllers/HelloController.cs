using Microsoft.AspNetCore.Mvc;
using Principal.Filters;

namespace Principal.Controllers
{

    [Route("allo")]
    public class HelloController : Controller
    {
        [HttpGet()]
        [MyFilter]
        [Route("{nom?}")]
        public IActionResult Index(string nom)
        {
            return Content($"Bonjour {nom}");
        }

        [HttpGet("test")]
        public IActionResult Test() {
            return Redirect("https://www.google.com");
        }

    }
}
