using System;
using System.Linq.Expressions;
using PrivateZone.Core.Specifications.Base;

namespace PrivateZone.Tests.Infrastructure.Fakes
{
    public class TrueSpecification : Specification<FakeEntity>
    {
        public override Expression<Func<FakeEntity, bool>> Predicate
        {
            get { return entity => true; }
        }
    }
}