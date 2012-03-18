using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoPage:IApolloPage
    {
        [BsonId]
        public ObjectId _id
        {
            get;
            set;
        }


        public string Id
        {
            get { return _id.ToString(); }
        }

        public string Url
        {
            get;
            set;
        }

        public int Hits
        {
            get;
            set;
        }
        public DateTime Created { get; set; }
        public int Version { get; set; }
    }
}
