using System;
using System.Linq;
using System.Linq.Expressions;

namespace PrivateZone.Core.Specifications.Base
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Predicate { get; }

        bool IsSatisfiedBy(TEntity item);

        IQueryable<TEntity> SatisfyFrom(IQueryable<TEntity> candidates);
    }
}