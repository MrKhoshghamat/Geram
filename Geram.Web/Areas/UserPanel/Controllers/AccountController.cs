﻿using Geram.Application.Services.Interfaces;
using Geram.Domain.ViewModels.UserPanel.Account;
using Microsoft.AspNetCore.Mvc;

namespace Geram.Web.Areas.UserPanel.Controllers
{
    public class AccountController : UserPanelBaseController
    {
        #region Ctor

        private readonly IStateService _stateService;

        public AccountController(IStateService stateService)
        {
            _stateService = stateService;
        }

        #endregion

        #region Edit User Info

        [HttpGet]
        public async Task<IActionResult> EditInfo()
        {
            ViewData["States"] = await _stateService.GetAllStates();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInfo(EditUserViewModel editUser)
        {
            

            return View();
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
