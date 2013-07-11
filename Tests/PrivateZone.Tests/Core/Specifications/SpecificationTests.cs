using NUnit.Framework;
using PrivateZone.Tests.Infrastructure.Fakes;
using SharpTestsEx;

namespace PrivateZone.Tests.Core.Specifications
{
    [TestFixture]
    public class SpecificationTests
    {
        [Test]
        public void IsSatisfiedBy_PredicateIsTrue_ReturnsTrue()
        {
            var spec = new TrueSpecification();

            var result = spec.IsSatisfiedBy(new FakeEntity());

            result.Should().Be.True();
        }
    }
}