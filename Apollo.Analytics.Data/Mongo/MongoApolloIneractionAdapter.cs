using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Abstractions;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoApolloIneractionAdapter:IApolloInteraction
    {
        private MongoInteraction _i;
        public MongoApolloIneractionAdapter(MongoInteraction i)
        {
            _i = i;
        }

        public string UserId
        {
            get
            {
                return _i.UserId.ToString();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string PageId
        {
            get
            {
                return _i.PageId.ToString();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Code
        {
            get
            {
                return _i.Code;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Dictionary<string, object> Arguments
        {
            get { return _i.Args.ToDictionary(); }
        }
    }
}
