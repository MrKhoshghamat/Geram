using Geram.Domain.Entities.Account;
using Geram.Domain.Entities.SiteSetting;
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
        public DbSet<EmailSetting> EmailSettings { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data

            var date = DateTime.MinValue;

            modelBuilder.Entity<EmailSetting>().HasData(new EmailSetting()
            {
                CreateDate = date,
                DisplayName = "Geram",
                EnableSSL = true,
                From = "khoshghamatprojects@gmail.com",
                Id = 1,
                IsDefault = true,
                IsDeleted = false,
                Password = "1234HuneR",
                Port = 587,
                SMTP = "smtp.gmail.com"
            });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
