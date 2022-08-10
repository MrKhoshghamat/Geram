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

        #region Email Activation

        Task<bool> ActivateUserEmail(string activationCode);

        #endregion

        #region Forgot Password

        Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel forgotPassword);

        #endregion

        #region Reset Password

        Task<ResetPasswordResult> ResetPassword(ResetPasswordViewModel resetPassword);
        Task<User> GetUserByActivationCode(string activationCode);

        #endregion

        #region User Panel

        Task<User?> GetUserById(long userId);

        #endregion
    }
}
