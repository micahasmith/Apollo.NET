using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using Apollo.Analytics.Abstractions;
using Apollo.Analytics.Abstractions.Data;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoPageRepository:IPageRepository
    {
        private MongoDatabase _md;
        private string _dbname;
        private static string _CollectionName = "ApolloPage";

        public MongoPageRepository(string dbname)
        {
            _dbname = dbname;
            //var _md = GetDb();
            //_md = MongoServer.Create().GetDatabase(dbname);
            //_md.DropCollection(_CollectionName);
        }
        private MongoDatabase GetDb()
        {
            //var ms = MongoServer.Create();
            //var md = ms.GetDatabase(_dbname);
            //return md;
            var uw = MongoUnitOfWork.Factory();
            _md = uw.GetServer().GetDatabase(_dbname);
            return _md;
        }
        private MongoCollection GetCollection()
        {
            var collection = GetDb().GetCollection(_CollectionName);
            return collection;
        }

        public void RegisterHit(string url)
        {
            var c=GetCollection();
            //var p = c.FindOneAs<MongoPage>(Query.EQ("Url",url));
            var p=c.FindAndModify(
                Query.EQ("Url", url),
                SortBy.Null,
                Update.Inc("Hits",1),
                false,false

                );
            if(p.ModifiedDocument==null)
            {
                c.Insert(new BsonDocument()
                    .Add("Created",new BsonDateTime(DateTime.Now))
                    .Add("Url",url)
                    .Add("Hits", new BsonInt64(1))
                    .Add("Version", new BsonInt64(1))
                    );
            }
            //else
            //{
            //    p.Hits++;
            //    c.Save<MongoPage>(p);
            //}
        }
        public IEnumerable<IApolloPage> GetTopPages(int num)
        {
            var c = GetCollection();
            var p=c.FindAllAs<MongoPage>()
                .SetSortOrder(SortBy.Descending("Hits"))
                .SetLimit(num);

            return p;
        }
    }
}
