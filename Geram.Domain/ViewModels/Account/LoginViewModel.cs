using System.ComponentModel.DataAnnotations;
using Geram.Domain.ViewModels.Common;

namespace Geram.Domain.ViewModels.Account
{
    public class LoginViewModel : GoogleRecaptchaViewModel
    {
        [Display(Name = "ایمیل")]
        [MaxLength(25, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public enum LoginResult
    {
        Success,
        UserIsBanned,
        UserNotFound,
        EmailNotActivated
    }
}
