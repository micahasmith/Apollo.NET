using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Abstractions;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoApolloUserAdapter:IApolloUser
    {
        private readonly MongoUser _u;
        public MongoApolloUserAdapter(MongoUser u)
        {
            _u = u;
        }
        public string Id
        {
            get { return _u._id.ToString(); }
        }

        public DateTime Created
        {
            get { return _u.Created; }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime LastHit
        {
            get
            {
                return _u.LastHit;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Version
        {
            get
            {
                return _u.Version;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Dictionary<string, object> Arguments
        {
            get { return _u.Args.ToDictionary(); }
        }
    }
}
