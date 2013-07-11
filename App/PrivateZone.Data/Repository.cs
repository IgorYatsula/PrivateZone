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
using MongoDB.Driver.Linq;
using PrivateZone.Core.Data;
using PrivateZone.Core.Specifications.Base;

namespace PrivateZone.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
    {
        private readonly MongoCollection<TEntity> collection;

        public Repository(string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            var database = mongoClient.GetServer().GetDatabase(mongoUrl.DatabaseName);
            this.collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public Repository(MongoCollection<TEntity> collection)
        {
            this.collection = collection;
        }

        public void SaveOrUpdate(TEntity entity)
        {
            this.collection.Save(entity);
        }

        public void Remove(ISpecification<TEntity> spec)
        {
            IMongoQuery query = Query<TEntity>.Where(spec.Predicate);
            this.collection.Remove(query);
        }

        public IFinder<TEntity> Find
        {
            get { return new Finder<TEntity>(this.collection.AsQueryable()); }
        }
    }
}
