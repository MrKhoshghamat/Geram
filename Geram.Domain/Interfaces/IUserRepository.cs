using Geram.Domain.Entities.Account;

namespace Geram.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsExistUserByEmail(string email);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByActivationCode(string activationCode);
        Task Save();
    }
}
