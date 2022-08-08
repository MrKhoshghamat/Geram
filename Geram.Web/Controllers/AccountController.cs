using Microsoft.AspNetCore.Mvc;

namespace Geram.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Login

        public IActionResult Login()
        {
            return View();
        }

        #endregion

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        #endregion
    }
}
