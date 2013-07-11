using System;
using System.Linq;
using System.Linq.Expressions;

namespace PrivateZone.Core.Specifications.Base
{
    public abstract class Specification<TEntity> : ISpecification<TEntity>
    {
        public abstract Expression<Func<TEntity, bool>> Predicate { get; }
        
        public virtual bool IsSatisfiedBy(TEntity item)
        {
            return SatisfyFrom(new[] {item}.AsQueryable()).Any();
        }

        public virtual IQueryable<TEntity> SatisfyFrom(IQueryable<TEntity> candidates)
        {
            return candidates.Where(Predicate).AsQueryable();
        }
    }
}