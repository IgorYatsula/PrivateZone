using System;
using System.Collections.Generic;
using System.Linq;
using PrivateZone.Core.Exceptions;
using PrivateZone.Core.Specifications.Base;

namespace PrivateZone.Core.Data
{
    public class Finder<TEntity> : IFinder<TEntity>
    {
        private readonly IQueryable<TEntity> candidates;

        public Finder(IQueryable<TEntity> candidates)
        {
            Check.Require<ArgumentNullException>(candidates != null, "Can't create instance of Finder because constructor argument candidates is null");

            this.candidates = candidates;
        }

        #region Implementation of IFinder<TEntity>

        public IList<TEntity> All()
        {
            return candidates.ToList();
        }

        public IList<TEntity> All(ISpecification<TEntity> specification)
        {
            Check.Require<ArgumentNullException>(specification != null, "Unable gets all entities by specification which is null");

            var result = specification.SatisfyFrom(candidates).ToList();

            return result;
        }

        public TEntity One(ISpecification<TEntity> specification)
        {
            Check.Require<ArgumentNullException>(specification != null, "Unable gets entity by specification which is null");

            TEntity result = specification.SatisfyFrom(candidates).FirstOrDefault();

            return result;
        }

        #endregion
    }
}