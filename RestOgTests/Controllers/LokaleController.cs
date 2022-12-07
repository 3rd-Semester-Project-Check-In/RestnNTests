using Microsoft.AspNetCore.Mvc;

namespace RestOgTests.Controllers
{
    public class LokaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
