using Geram.Application.Services.Interfaces;
using Geram.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace Geram.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Ctor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        #endregion

        #region Register

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel register)
        {
            return View();
        }

        #endregion
    }
}
