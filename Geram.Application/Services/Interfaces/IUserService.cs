using Geram.Domain.ViewModels.Account;

namespace Geram.Application.Services.Interfaces
{
    public interface IUserService
    {
        #region Register

        Task<RegisterResult> RegisterUser(RegisterViewModel register);

        #endregion
    }
}
