using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoInteraction
    {
        [BsonId]
        public ObjectId _id
        {
            get;
            set;
        }
        public ObjectId UserId
        {
            get;
            set;
        }

        public ObjectId PageId
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public BsonDocument Args
        {
            get;
            set;
        }
        public DateTime Created { get; set; }
        public static MongoInteraction Factory()
        {
            var i = new MongoInteraction();
            i.Created = DateTime.Now;
            i.Args = new BsonDocument();

            return i;
        }
    }
}
