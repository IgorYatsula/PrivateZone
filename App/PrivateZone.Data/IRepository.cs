using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace PrivateZone.Data
{
    public interface IRepository
    {
        void SaveOrUpdate<T>(T entity);
        void Remove<T>(Expression<Func<T, bool>> expression);
    }
}
