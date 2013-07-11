using System;
using System.Linq.Expressions;

namespace PrivateZone.Core.Specifications.Base
{
    internal class QuerySpecification<TEntity> : Specification<TEntity>
    {
        private readonly Expression<Func<TEntity, bool>> expression;

        public override Expression<Func<TEntity, bool>> Predicate
        {
            get
            {
                return this.expression;
            }
        }

        public QuerySpecification(Expression<Func<TEntity, bool>> expression)
        {
            this.expression = expression;
        }
    }
}