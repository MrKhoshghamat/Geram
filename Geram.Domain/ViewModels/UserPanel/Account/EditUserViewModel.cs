using System.ComponentModel.DataAnnotations;

namespace Geram.Domain.ViewModels.UserPanel.Account
{
    public class EditUserViewModel
    {
        [Display(Name = "نام")]
        [MaxLength(25, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        public string LastName { get; set; }

        [Display(Name = "شماره تماس")]
        [MaxLength(20, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "تاریخ تولد")]
        [RegularExpression(@"^\d{4}/((0[1-9])|(1[012]))/((0[1-9]|[12]\d)|3[01])$", ErrorMessage = "تاریخ وارد شده معتبر نمیباشد")]
        public string? BirthDate { get; set; }

        [Display(Name = "کشور")]
        public long? CountryId { get; set; }

        [Display(Name = "شهر")]
        public long? CityId { get; set; }

        public bool GetNewsLetter { get; set; }
    }
}
