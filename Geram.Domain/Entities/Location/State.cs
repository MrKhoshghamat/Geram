using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Geram.Domain.Entities.Account;
using Geram.Domain.Entities.Common;

namespace Geram.Domain.Entities.Location
{
    public class State : BaseEntity
    {
        #region Properties

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید.")]
        [MaxLength(25, ErrorMessage = "{0} نمیتواند بیشتر از {1} کارکتر باشد.")]
        public string Title { get; set; }

        public long? ParentId { get; set; }

        #endregion

        #region Relations

        public State? Parent { get; set; }

        [InverseProperty("Country")]
        public ICollection<User> UserCountries { get; set; }

        [InverseProperty("City")]
        public ICollection<User> UserCities { get; set; }

        #endregion
    }
}
