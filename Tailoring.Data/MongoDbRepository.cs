using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Tailoring.Models;


namespace Tailoring.Data {
    public class MongoDbRepository<TEntity>: IRepository<TEntity> where TEntity : EntityBase {
        private IMongoDatabase _database;
        private IMongoClient _client;
        private IMongoCollection<TEntity> _collection;
        private const string DATABASENAME = "tailordb";
        //private const string CLOUDCONNECTIONSTRING = "mongodb://testuser:testuser@ds048319.mlab.com:48319/tailordb?connecttimeout=60000&maxconnectionlifetime=60000&sockettimeout=60000";
        private const string CLOUDCONNECTIONSTRING = "mongodb://testuser:testuser@ds048319.mlab.com:48319/tailordb";
        private const string LOCALCONNECTIONSTRING = "mongodb://localhost";
        public MongoDbRepository() {
            _client = new MongoClient(LOCALCONNECTIONSTRING);

            _database = _client.GetDatabase(DATABASENAME);
            _collection = this._database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public void Insert(TEntity entity) {
            this._database.GetCollection<TEntity>(typeof(TEntity).Name).InsertOneAsync(entity);
        }
        public void Update(TEntity entity) {
            if (entity.Id == null)
                Insert(entity);

            _collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions {
                IsUpsert = true
            });
        }
        public IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate) {
            return _collection.AsQueryable<TEntity>()
                    .Where(predicate.Compile())
                        .ToList();
        }
        public IEnumerable<TEntity> GetAll() {
            return this._database.GetCollection<TEntity>(typeof(TEntity).Name).Find(new BsonDocument()).ToListAsync().Result;
        }
        public TEntity Get(ObjectId id) {
            return this._database.GetCollection<TEntity>(typeof(TEntity).Name).Find(x => x.Id.Equals(id)).FirstOrDefaultAsync().Result;
        }
        public TEntity Save(TEntity entity) {
            var collection = this._database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions {
                IsUpsert = true
            });

            return entity;

        }
        public void Delete(ObjectId id) {
            var collection = this._database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.DeleteOneAsync(x => x.Id.Equals(id));
        }
        public void Delete(TEntity entity) {
            var collection = this._database.GetCollection<TEntity>(typeof(TEntity).Name);
            collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }
    }
    public interface IRepository<TEntity> where TEntity : EntityBase {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(ObjectId id);
        IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity Get(ObjectId id);
        TEntity Save(TEntity entity);
    }
}