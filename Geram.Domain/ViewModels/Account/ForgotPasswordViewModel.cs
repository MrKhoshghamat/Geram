using System.ComponentModel.DataAnnotations;
using Geram.Domain.ViewModels.Common;

namespace Geram.Domain.ViewModels.Account
{
    public class ForgotPasswordViewModel : GoogleRecaptchaViewModel
    {
        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Email { get; set; }
    }

    public enum ForgotPasswordResult
    {
        UserBanned,
        UserNotFound,
        Success
    }
}
