using Microsoft.AspNetCore.Mvc;

namespace HRTool.Controllers
{
    public class DutyController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}