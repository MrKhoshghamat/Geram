using System.ComponentModel.DataAnnotations;
using Geram.Domain.Entities.Common;

namespace Geram.Domain.Entities.Account
{
    public class User : BaseEntity
    {
        #region Properties

        [Display(Name = "نام")]
        [MaxLength(25, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        public string? LastName { get; set; }

        [Display(Name = "شماره تماس")]
        [MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(25, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string Password { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBanned { get; set; }
        public string EmailActivationCode { get; set; }
        public string Avatar { get; set; }

        #endregion

        #region Relations

        

        #endregion
    }
}
