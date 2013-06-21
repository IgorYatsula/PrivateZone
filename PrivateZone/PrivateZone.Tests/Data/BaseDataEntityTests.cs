using NUnit.Framework;
using PrivateZone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpTestsEx;
using MongoDB.Bson;

namespace PrivateZone.Tests.Data
{
    [TestFixture]
    public class BaseDataEntityTests
    {
        [Test]
        public void Ctor_IdGeneration_GeneratedNewUniqueId()
        {
            var entity = new FakeEntity();
            entity.Id.Should().Not.Be.EqualTo(ObjectId.Empty);
        }

        class FakeEntity : BaseDataEntity
        { 
        }
    }
}
