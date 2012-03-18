using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoInteractionRepository:MongoBaseRepository<MongoInteraction>
    {
        public MongoInteractionRepository(string dbname)
            :base(dbname,"ApolloInteraction",MongoInteraction.Factory)
        {

        }
    }
}
