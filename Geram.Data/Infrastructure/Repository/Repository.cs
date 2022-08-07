using System.Linq.Expressions;
using Geram.Domain.Repository;

namespace Geram.Data.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityById(long entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetEntities(Expression<Func<bool, TEntity>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity(Expression<Func<bool, TEntity>> predicate)
        {
            throw new NotImplementedException();
        }

        public void CreateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(long entityId)
        {
            throw new NotImplementedException();
        }
    }
}
