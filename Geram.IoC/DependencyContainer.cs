using Geram.Application.Services.Implementations;
using Geram.Application.Services.Interfaces;
using Geram.Data.Repositories;
using Geram.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Geram.IoC
{
    public class DependencyContainer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISiteSettingRepository, SiteSettingRepository>();

            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();

            #endregion
        }
    }
}
