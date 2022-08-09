using Geram.Data.Context;
using Geram.Domain.Entities.Account;
using Geram.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
