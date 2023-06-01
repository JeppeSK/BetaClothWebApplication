using Microsoft.AspNetCore.Mvc;

namespace ClothWebApplication.Controllers
{
    public class ApiTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
