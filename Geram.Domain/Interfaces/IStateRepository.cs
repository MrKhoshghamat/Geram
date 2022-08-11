using Geram.Domain.Entities.Location;

namespace Geram.Domain.Interfaces
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStates(long? stateId = null);
    }
}
