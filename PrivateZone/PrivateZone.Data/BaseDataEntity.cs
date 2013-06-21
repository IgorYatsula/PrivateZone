using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateZone.Data
{
    public abstract class BaseDataEntity
    {
        public ObjectId Id { get; private set; }

        public BaseDataEntity()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}
