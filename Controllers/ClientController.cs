using Microsoft.AspNetCore.Mvc;

namespace FreelanceManager.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
