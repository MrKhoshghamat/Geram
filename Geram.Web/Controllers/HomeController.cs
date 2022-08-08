using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Geram.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}