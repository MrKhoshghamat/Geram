using Geram.Domain.Entities.Account;
using Geram.Domain.ViewModels.Account;

namespace Geram.Application.Services.Interfaces
{
    public interface IUserService
    {
        #region Register

        Task<RegisterResult> RegisterUser(RegisterViewModel register);

        #endregion

        #region Login

        Task<LoginResult> CheckUserForLogin(LoginViewModel login);
        Task<User> GetUserByEmail(string email);

        #endregion
    }
}
