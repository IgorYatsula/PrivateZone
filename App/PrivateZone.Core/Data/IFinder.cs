using System.Collections.Generic;
using PrivateZone.Core.Specifications.Base;

namespace PrivateZone.Core.Data
{
    public interface IFinder<TEntity>
    {
        IList<TEntity> All();

        IList<TEntity> All(ISpecification<TEntity> specification);

        TEntity One(ISpecification<TEntity> specification);
    }
}