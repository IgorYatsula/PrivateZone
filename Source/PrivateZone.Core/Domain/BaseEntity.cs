using MongoDB.Bson;

namespace PrivateZone.Core.Domain
{
    public abstract class BaseEntity
    {
        public ObjectId Id { get; private set; }

        protected BaseEntity()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}