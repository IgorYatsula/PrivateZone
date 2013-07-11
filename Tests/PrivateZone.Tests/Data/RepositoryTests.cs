using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using PrivateZone.Data;
using PrivateZone.Tests.Infrastructure.Fakes;
using SharpTestsEx;

namespace PrivateZone.Tests.Data
{
    [TestFixture]
    public class RepositoryTests
    {
        public static readonly MongoDatabase MongoDatabase = new MongoDatabase(new MongoServer(new MongoServerSettings()), "mockDatabase", new MongoDatabaseSettings());
        public static readonly MongoCollectionSettings MongoCollectionSettings = new MongoCollectionSettings();

        private Mock<MongoCollection<FakeEntity>> mongoCollectionMock;

        private Repository<FakeEntity> CreateAndSetupRepository()
        {
            this.mongoCollectionMock = new Mock<MongoCollection<FakeEntity>>(MongoDatabase, typeof(FakeEntity).Name, MongoCollectionSettings);
            return new Repository<FakeEntity>(this.mongoCollectionMock.Object);
        }

        [Test]
        public void Ctor_ThroughConnectionString_DoesntThrowExceptions()
        {
            // Assert
            Executing.This(() => new Repository<FakeEntity>("mongodb://server/DbName")).Should().NotThrow();
        }

        [Test]
        public void Ctor_ThroughMongoCollection_DoesntThrowExceptions()
        {
            var collection = MongoDatabase.GetCollection<FakeEntity>(typeof (FakeEntity).Name);

            // Assert
            Executing.This(() => new Repository<FakeEntity>(collection)).Should().NotThrow();
        }

        [Test]
        public void SaveOrUpdate_MongoCalls_CallsMongoMethods()
        {
            // Arrange
            var repo = this.CreateAndSetupRepository();
            var testEntity = new FakeEntity();

            // Act
            repo.SaveOrUpdate(testEntity);

            // Assert
            this.mongoCollectionMock.Verify(col => col.Save(testEntity), Times.Once());
        }

        [Test]
        public void Remove_MongoCalls_CallsMongoMethods()
        {
            // Arrange
            var repo = this.CreateAndSetupRepository();
            
            // Act
            repo.Remove(new TrueSpecification());

            // Assert
            this.mongoCollectionMock.Verify(col => col.Remove(It.IsAny<IMongoQuery>()), Times.Once());
        }

        [Test]
        public void Find_CreatingFinder_ReturnsNotNull()
        {
            // Arrange
            var repo = this.CreateAndSetupRepository();

            // Act
            var finder = repo.Find;

            // Assert
            finder.Should().Not.Be.Null();
        }
    }
}