using Geram.Data.Context;
using Geram.Domain.Entities.Location;
using Geram.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Geram.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        #region Ctor

        private readonly GeramDbContext _context;

        public StateRepository(GeramDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<List<State>> GetAllStates(long? stateId = null)
        {
            var states = _context.States.Where(s => !s.IsDeleted).AsQueryable();

            if (stateId.HasValue)
            {
                states = states.Where(s => s.ParentId.HasValue && s.ParentId.Value.Equals(stateId.Value));
            }
            else
            {
                states = states.Where(s => s.ParentId.Equals(null));
            }

            return await states.ToListAsync();
        }
    }
}
