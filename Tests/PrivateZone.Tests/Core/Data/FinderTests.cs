using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using NUnit.Framework;
using PrivateZone.Core.Data;
using PrivateZone.Core.Domain;
using PrivateZone.Tests.Infrastructure.Fakes;
using SharpTestsEx;

namespace PrivateZone.Tests.Core.Data
{
    [TestFixture]
    public class FinderTests
    {
        private Finder<FakeEntity> TestedInstance { get; set; }
        private IList<FakeEntity> TestedCollection { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.TestedCollection = new[]
                {
                    new FakeEntity(),
                    new FakeEntity(),
                    new FakeEntity(),
                    new FakeEntity()
                };
            this.TestedInstance = new Finder<FakeEntity>(this.TestedCollection.AsQueryable());
        }

        [Test]
        public void Ctor_ParamCandidatesIsNull_ThrowsArgumentNullException()
        {
            Executing.This(() => new Finder<FakeEntity>(null)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void All_ParamSpecificationIsNull_ThrowsArgumentNullException()
        {
            Executing.This(() => this.TestedInstance.All(null)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void One_ParamSpecificationIsNull_ThrowsArgumentNullException()
        {
            Executing.This(() => this.TestedInstance.One(null)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void One_TrueSpecification_ReturnsFirstEntity()
        {
            var expectedAccount = this.TestedCollection[0];

            var result = this.TestedInstance.One(new TrueSpecification());

            result.Should().Be.EqualTo(expectedAccount);
        }

        [Test]
        public void All_TrueSpecification_ReturnsAllEntities()
        {
            var result = this.TestedInstance.All(new TrueSpecification());

            result.Should().Have.SameSequenceAs(this.TestedCollection);
        }

        [Test]
        public void All_FindingAllEntities_RetuensAllEntities()
        {
            var result = this.TestedInstance.All();

            result.Should().Have.SameSequenceAs(this.TestedCollection);
        }
    }
}