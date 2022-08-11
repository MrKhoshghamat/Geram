using System.ComponentModel.DataAnnotations;

namespace Geram.Domain.ViewModels.UserPanel.Account
{
    public class ChangeUserPasswordViewModel
    {
        [Display(Name = "کلمه عبور فعلی")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string OldPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }
    }

    public enum ChangeUserPasswordResult
    {
        OldPasswordIsNotValid,
        Success
    }
}
