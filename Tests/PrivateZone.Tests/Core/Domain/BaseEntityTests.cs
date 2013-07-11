using MongoDB.Bson;
using NUnit.Framework;
using PrivateZone.Core.Domain;
using SharpTestsEx;

namespace PrivateZone.Tests.Core.Domain
{
    public class BaseEntityTests
    {
        [Test]
        public void Ctor_IdGeneration_GeneratedNewUniqueId()
        {
            var entity = new FakeEntity();
            entity.Id.Should().Not.Be.EqualTo(ObjectId.Empty);
        }

        class FakeEntity : BaseEntity
        {
        } 
    }
}