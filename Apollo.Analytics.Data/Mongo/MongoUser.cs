using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using Apollo.Analytics.Abstractions;
using MongoDB.Bson.Serialization.Attributes;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoUser
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastHit { get; set; }
        public int Version { get; set; }
        public BsonDocument Args { get; set; }


        public static MongoUser Factory()
        {
            var u = new MongoUser();
            u.Created = DateTime.Now;
            u.LastHit = DateTime.Now;
            u.Args = new BsonDocument();

            return u;
        }

    }
}
