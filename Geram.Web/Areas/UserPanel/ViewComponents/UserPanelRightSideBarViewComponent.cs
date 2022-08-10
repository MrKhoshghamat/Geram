using System.Net;
using Geram.Application.Extensions;
using Geram.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Geram.Web.Areas.UserPanel.ViewComponents
{
    public class UserPanelRightSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IUserService _userService;

        public UserPanelRightSideBarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserById(HttpContext.User.GetUserId());

            return View("UserPanelRightSideBar", user);
        }
    }
}
