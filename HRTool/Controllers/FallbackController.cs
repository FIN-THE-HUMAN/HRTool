using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    public class FallbackController : Controller
    {
        // GET
  
        public IActionResult Index()
        {
            return View();
        }
    }
}