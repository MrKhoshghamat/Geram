using Geram.Data.Context;
using Geram.Domain.Entities.SiteSetting;
using Geram.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Geram.Data.Repositories
{
    public class SiteSettingRepository : ISiteSettingRepository
    {
        #region Ctor

        private readonly GeramDbContext _context;

        public SiteSettingRepository(GeramDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<EmailSetting> GetDefaultEmail()
        {
            return await _context.EmailSettings.FirstOrDefaultAsync(s => !s.IsDeleted && s.IsDefault);
        }
    }
}
