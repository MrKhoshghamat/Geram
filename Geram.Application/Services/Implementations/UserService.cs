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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            // TODO Send Email

            #endregion

            return RegisterResult.Success;
        }

        #endregion
    }
}
