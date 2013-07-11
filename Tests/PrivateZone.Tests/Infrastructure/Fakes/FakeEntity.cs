using MongoDB.Bson;
using PrivateZone.Core.Domain;

namespace PrivateZone.Tests.Infrastructure.Fakes
{
    public class FakeEntity : BaseEntity
    {
        public new ObjectId Id 
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
    }
}