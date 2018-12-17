using Microsoft.AspNetCore.Mvc;

namespace FrontWeb
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}