using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using Apollo.Analytics.Abstractions;
using MongoDB.Driver.Builders;
using Apollo.Analytics.Abstractions.Data;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoUserRepository:IUserRepository
    {
        private MongoDatabase _md;
        private string _dbname;
        private static string _UserCollection = "ApolloUser";

        public MongoUserRepository(string dbname)
        {
            _dbname = dbname;
            //var _md = GetDb();
           // _md = MongoServer.Create().GetDatabase(dbname);
            //MongoServer.Create().GetDatabase(_dbname).DropCollection(_UserCollection);
           
        }
        private MongoDatabase GetDb()
        {
            //var ms = MongoServer.Create();
            //var md = ms.GetDatabase(_dbname);
            //return md;

            //return _md;
            var uw = MongoUnitOfWork.Factory();
            _md = uw.GetServer().GetDatabase(_dbname);
            return _md;
        }
        private MongoCollection GetCollection()
        {
            var collection = GetDb().GetCollection(_UserCollection);
            return collection;
        }
        public IApolloUser Get(string id)
        {
            var c = GetCollection();
            var u = c.FindOneByIdAs<MongoUser>(ObjectId.Parse(id));
            if (u == null) 
                return null;
            return new MongoApolloUserAdapter(u);

        }
        public void HeartBeat(string id)
        {
            var c = GetCollection();
            c.FindAndModify(Query.EQ("_id", id),
                SortBy.Null,
                Update.Set("LastHit", new BsonDateTime(DateTime.Now)));
        }

        public IApolloUser Create()
        {
            //BsonDocument user = new BsonDocument()
            //    .Add("Created", new BsonDateTime(DateTime.Now))
            //    .Add("LastHit", new BsonDateTime(DateTime.Now))
            //    .Add("Args",new BsonDocument())
            //    .Add("Version", new BsonInt64(1));

            var u = MongoUser.Factory();
            


            var collection = GetCollection();
            //var r=collection.Insert(user);
            collection.Save<MongoUser>(u);

            return new MongoApolloUserAdapter(u);
        }

        public void PushArguments(string userid,Dictionary<string,object> args)
        {
            var c = GetCollection();
            var u = c.FindOneByIdAs<MongoUser>(ObjectId.Parse(userid));
            foreach (var k in args.Keys)
            {
                if (u.Args[k] != null)
                    u.Args.Remove(k);
                //else
                //    u.Args.Add(new Dictionary<string, object>() { { k, args[k] } });
            }
            u.Args.Add(args);
            c.Save(u);
        }
    }
}
