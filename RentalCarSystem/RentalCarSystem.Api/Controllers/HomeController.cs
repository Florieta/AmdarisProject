using Microsoft.AspNetCore.Mvc;

namespace RentalCarSystem.Api.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
