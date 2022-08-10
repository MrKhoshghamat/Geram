using System.ComponentModel.DataAnnotations;
using Geram.Domain.ViewModels.Common;

namespace Geram.Domain.ViewModels.Account
{
    public class ResetPasswordViewModel : GoogleRecaptchaViewModel
    {
        [Required]
        public string EmailActivationCode { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
    }

    public enum ResetPasswordResult
    {
        UserNotFound,
        UserIsBanned,
        Success
    }
}
