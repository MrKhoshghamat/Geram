using Geram.Domain.Entities.SiteSetting;

namespace Geram.Domain.Interfaces
{
    public interface ISiteSettingRepository
    {
        Task<EmailSetting> GetDefaultEmail();
    }
}
