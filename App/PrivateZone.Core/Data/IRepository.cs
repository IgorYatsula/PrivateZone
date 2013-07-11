using PrivateZone.Core.Specifications.Base;

namespace PrivateZone.Core.Data
{
    public interface IRepository<TEntity>
    {
        void SaveOrUpdate(TEntity entity);

        void Remove(ISpecification<TEntity> spec);

        IFinder<TEntity> Find { get; }
    }
}