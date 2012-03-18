using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoBaseRepository<T>
    {
        private string _dbname;
        private string _cname;
        private Func<T> _factory;
        public MongoBaseRepository(string dbname, string collectionName,Func<T> factory)
        {
            _dbname = dbname;
            _cname = collectionName;
            _factory = factory;
        }
        protected MongoDatabase GetDb()
        {
            var uw = MongoUnitOfWork.Factory();
            var _md = uw.GetServer().GetDatabase(_dbname);
            return _md;
        }
        protected MongoCollection GetCollection()
        {
            var collection = GetDb().GetCollection(_cname);
            return collection;
        }
        public T Create()
        {
            return this.Create(_factory.Invoke());
        }
        /// <summary>
        /// Will insert/update based upon item passed in
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public T Save(T item)
        {
            var c = GetCollection();
            c.Save<T>(item);
            return i;
        }
        public T GetById(string id)
        {
            return GetCollection().FindOneByIdAs<T>(ObjectId.Parse(id));
        }
    }
}
