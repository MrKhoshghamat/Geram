using Geram.Application.Services.Interfaces;
using Geram.Domain.Interfaces;
using Geram.Domain.ViewModels.Common;

namespace Geram.Application.Services.Implementations
{
    public class StateService : IStateService
    {
        #region Ctor

        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        #endregion

        public async Task<List<SelectListViewModel>> GetAllStates(long? stateId = null)
        {
            var states = await _stateRepository.GetAllStates(stateId);
            return states.Select(s => new SelectListViewModel()
            {
                Id = s.Id,
                Title = s.Title,
            }).ToList();
        }
    }
}
