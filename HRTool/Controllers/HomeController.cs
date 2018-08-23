using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Done");
        }
    }
}
