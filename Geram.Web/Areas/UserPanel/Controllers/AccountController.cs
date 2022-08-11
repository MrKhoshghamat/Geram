using Geram.Application.Extensions;
using Geram.Application.Services.Interfaces;
using Geram.Domain.ViewModels.UserPanel.Account;
using Microsoft.AspNetCore.Mvc;

namespace Geram.Web.Areas.UserPanel.Controllers
{
    public class AccountController : UserPanelBaseController
    {
        #region Ctor

        private readonly IStateService _stateService;
        private readonly IUserService _userService;

        public AccountController(IStateService stateService, IUserService userService)
        {
            _stateService = stateService;
            _userService = userService;
        }

        #endregion

        #region Edit User Info

        [HttpGet]
        public async Task<IActionResult> EditInfo()
        {
            ViewData["States"] = await _stateService.GetAllStates();

            var result = await _userService.FillEditUserViewModel(HttpContext.User.GetUserId());

            if (result.CountryId.HasValue)
            {
                ViewData["Cities"] = await _stateService.GetAllStates(result.CountryId.Value);
            }

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInfo(EditUserViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.EditUserInfo(editUser, HttpContext.User.GetUserId());

                switch (result)
                {
                    case EditUserInfoResult.NotValidDate:
                        TempData[ErrorMessage] = "تاریخ وارد شده معتبر نمیباشد.";
                        break;
                    case EditUserInfoResult.Success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                        return RedirectToAction("EditInfo", "Account", new {area = "UserPanel"});
                   
                }
            }

            ViewData["States"] = await _stateService.GetAllStates();

            return View(editUser);
        }

        #endregion

        #region Load Cities

        public async Task<IActionResult> LoadCities(long countryId)
        {
            var result = await _stateService.GetAllStates(countryId);

            return new JsonResult(result);
        }

        #endregion
    }
}
