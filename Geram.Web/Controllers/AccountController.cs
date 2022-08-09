using System.Security.Claims;
using Geram.Application.Services.Interfaces;
using Geram.Domain.ViewModels.Account;
using Geram.Web.ActionFilters;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Geram.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Ctor

        private readonly IUserService _userService;
        private readonly ICaptchaValidator _captchaValidator;

        public AccountController(IUserService userService, ICaptchaValidator captchaValidator)
        {
            _userService = userService;
            _captchaValidator = captchaValidator;
        }

        #endregion

        #region Login

        [HttpGet("login")]
        [RedirectHomeIfLoggedInActionFilter]
        public IActionResult Login(string returnUrl = "")
        {
            var result = new LoginViewModel();

            if (!string.IsNullOrEmpty(returnUrl))
            {
                result.ReturnUrl = returnUrl;
            }
            return View(result);
        }

        [HttpPost("login"), ValidateAntiForgeryToken]
        [RedirectHomeIfLoggedInActionFilter]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(login.Captcha))
            {
                TempData[ErrorMessage] = "اعتبارسنجی گوگل با خطا مواجه شد. لطفا مجددا تلاش کنید.";
                return View(login);
            }

            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var result = await _userService.CheckUserForLogin(login);

            switch (result)
            {
                case LoginResult.UserIsBanned:
                    TempData[WarningMessage] = "دسترسی شما به سایت مسدود میباشد.";
                    break;
                case LoginResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد.";
                    break;
                case LoginResult.EmailNotActivated:
                    TempData[WarningMessage] = "یرای ورود به حساب کاربری ابتدا ایمیل خود را فعال کنید.";
                    break;
                case LoginResult.Success:

                    var user = await _userService.GetUserByEmail(login.Email);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties { IsPersistent = login.RememberMe };

                    await HttpContext.SignInAsync(principal, properties);

                    TempData[SuccessMessage] = "خوش آمدید";

                    if (!string.IsNullOrEmpty(login.ReturnUrl))
                    {
                        return Redirect(login.ReturnUrl);
                    }

                    return Redirect("/");
            }

            return View(login);
        }
        #endregion

        #region Register

        [HttpGet("register")]
        [RedirectHomeIfLoggedInActionFilter]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register"), ValidateAntiForgeryToken]
        [RedirectHomeIfLoggedInActionFilter]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(register.Captcha))
            {
                TempData[ErrorMessage] = "اعتبارسنجی گوگل با خطا مواجه شد. لطفا مجددا تلاش کنید.";
                return View(register);
            }

            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var result = await _userService.RegisterUser(register);

            switch (result)
            {
                case RegisterResult.EmailExists:
                    TempData[ErrorMessage] = "ایمیل وارد شده قبلا ثبت شده است";
                    break;
                case RegisterResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Login","Account");
            }

            return View(register);
        }

        #endregion

        #region Logout

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        #endregion

        #region Email Activation

        [HttpGet("activate-email/{activationCode}")]
        [RedirectHomeIfLoggedInActionFilter]
        public async Task<IActionResult> ActivationUserEmail(string activationCode)
        {
            var result = await _userService.ActivateUserEmail(activationCode);

            if (result)
            {
                TempData[SuccessMessage] = "حساب کاربری شما با موفقیت فعال شد.";
            }
            else
            {
                TempData[ErrorMessage] = "فعال سازی حساب کاربری شما با خطا مواجه شد.";
            }
            return RedirectToAction("Login", "Account");
        }

        #endregion
    }
}
