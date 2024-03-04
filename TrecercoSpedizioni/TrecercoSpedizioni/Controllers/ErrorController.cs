using Microsoft.AspNetCore.Mvc;

namespace TrecercoSpedizioni.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        public IActionResult Index()
        {
            return View("Error");
        }
    }
}
