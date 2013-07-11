using MongoDB.Bson;

namespace PrivateZone.Core.Domain
{
    public abstract class BaseEntity
    {
        public ObjectId Id { get; protected set; }

        protected BaseEntity()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}