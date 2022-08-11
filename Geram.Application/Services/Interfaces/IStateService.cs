using Geram.Domain.ViewModels.Common;

namespace Geram.Application.Services.Interfaces
{
    public interface IStateService
    {
        Task<List<SelectListViewModel>> GetAllStates(long? stateId = null);
    }
}
