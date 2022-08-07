using Geram.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;

namespace Geram.Data.Context
{
    public class GeramDbContext : DbContext
    {
        #region Ctor

        public GeramDbContext(DbContextOptions<GeramDbContext> options) : base(options)
        {
            
        }

        #endregion

        #region DbSet

        public DbSet<User> Users { get; set; }

        #endregion
    }
}
