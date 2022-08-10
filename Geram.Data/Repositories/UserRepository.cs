using Geram.Data.Context;
using Geram.Domain.Entities.Account;
using Geram.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Geram.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Ctor

        private readonly GeramDbContext _context;

        public UserRepository(GeramDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<bool> IsExistUserByEmail(string email)
        {
            return await _context.Users.AnyAsync(s => s.Email == email);
        }

        public async Task CreateUser(User user)
        {
            await _context.AddAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            _context.Update(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.Email.Equals(email));
        }

        public async Task<User> GetUserByActivationCode(string activationCode)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.EmailActivationCode.Equals(activationCode));
        }

        public async Task<User?> GetUserById(long userId)
        {
            return await _context.Users.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id.Equals(userId));
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
