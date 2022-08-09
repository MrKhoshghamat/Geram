using Geram.Application.Generators;
using Geram.Application.Security;
using Geram.Application.Services.Interfaces;
using Geram.Application.Statics;
using Geram.Domain.Entities.Account;
using Geram.Domain.Interfaces;
using Geram.Domain.ViewModels.Account;

namespace Geram.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Ctor

        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        #endregion

        #region Register
        public async Task<RegisterResult> RegisterUser(RegisterViewModel register)
        {
            // Check Email Exists
            if (await _userRepository.IsExistUserByEmail(register.Email.SanitizeText().Trim().ToLower()))
            {
                return RegisterResult.EmailExists;
            }

            // Hash Password
            var password = PasswordHelper.EncodePasswordMd5(register.Password.SanitizeText());

            // Create User
            var user = new User()
            {
                Avatar = PathTools.DefaultUserAvatar,
                Email = register.Email.SanitizeText().Trim().ToLower(),
                Password = password,
                EmailActivationCode = CodeGenerator.CreateActivationCode(),
            };

            // Add To Database
            await _userRepository.CreateUser(user);
            await _userRepository.Save();

            #region Send Activation Email

            var body = $@"
                <div>برای فعالسازی حساب کاربری خود، بر روی لینک زیر کلیک کنید.</div>
                <a href='{PathTools.SiteAddress}/activate-email/{user.EmailActivationCode}'>فعالسازی حساب کاربری</a>";

            await _emailService.SendEmail(user.Email, "فعالسازی حساب کاربری", body);

            #endregion

            return RegisterResult.Success;
        }

        #endregion

        #region Login

        public async Task<LoginResult> CheckUserForLogin(LoginViewModel login)
        {
            var user = await _userRepository.GetUserByEmail(login.Email.SanitizeText().Trim().ToLower());

            if (user == null) return LoginResult.UserNotFound;

            var hashedPassword = PasswordHelper.EncodePasswordMd5(login.Password.SanitizeText());

            if(hashedPassword != user.Password) return LoginResult.UserNotFound;

            if(user.IsDeleted) return LoginResult.UserNotFound;

            if (user.IsBanned) return LoginResult.UserIsBanned;

            if (!user.IsEmailConfirmed) return LoginResult.EmailNotActivated;

            return LoginResult.Success;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        #endregion

        #region Activation Email

        public async Task<bool> ActivateUserEmail(string activationCode)
        {
            var user = await _userRepository.GetUserByActivationCode(activationCode);

            if(user == null) return false;

            if (user.IsBanned || user.IsDeleted) return false;

            user.IsEmailConfirmed = true;
            user.EmailActivationCode = CodeGenerator.CreateActivationCode();

            await _userRepository.UpdateUser(user);
            await _userRepository.Save();

            return true;
        }

        #endregion

        #region Forgot Password

        public async Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            var email = forgotPassword.Email.SanitizeText().Trim().ToLower();

            var user = await _userRepository.GetUserByEmail(email);

            if (user == null || user.IsDeleted) return ForgotPasswordResult.UserNotFound;

            if (user.IsBanned) return ForgotPasswordResult.UserBanned;

            #region Send Forgot Password Email

            var body = $@"
                <div>برای فراموشی کلمه عبور خود، بر روی لینک زیر کلیک کنید.</div>
                <a href='{PathTools.SiteAddress}/reset-password/{user.EmailActivationCode}'>فراموشی کلمه عبور</a>";

            await _emailService.SendEmail(user.Email, "فراموشی کلمه عبور", body);

            #endregion

            return ForgotPasswordResult.Success;
        }

        #endregion
    }
}
