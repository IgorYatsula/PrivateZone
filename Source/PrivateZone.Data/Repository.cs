using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Inflector;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;

namespace PrivateZone.Data
{
    public class Repository : IRepository
    {
        private readonly string connection;
        private readonly MongoDatabase db;
        private readonly MongoClient client;

        public Repository(string connection)
        {
            this.connection = connection;
            var mongoUrl = new MongoUrl(this.connection);
            this.client = new MongoClient(mongoUrl);
            this.db = this.client.GetServer().GetDatabase(mongoUrl.DatabaseName);
        }

        public void SaveOrUpdate<T>(T document)
        {
            this.GetCollection<T>().Save(document);
        }

        public void Remove<T>(Expression<Func<T, bool>> expression)
        {
            IMongoQuery query = Query<T>.Where(expression);
            this.Remove<T>(query);
        }

        private void Remove<T>(IMongoQuery query)
        {
            this.GetCollection<T>().Remove(query);
        }

        private MongoCollection<T> GetCollection<T>()
        {
            var collectionName = typeof (T).Name.Pluralize();
            return this.db.GetCollection<T>(collectionName);
        }
    }
}
