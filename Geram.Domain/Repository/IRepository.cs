using System.Linq.Expressions;

namespace Geram.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllEntities();
        TEntity GetEntityById(long entityId);
        IEnumerable<TEntity> GetEntities(Expression<Func<bool, TEntity>> predicate);
        TEntity GetEntity(Expression<Func<bool, TEntity>> predicate);
        void CreateEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        void DeleteEntity(long entityId);
    }
}
