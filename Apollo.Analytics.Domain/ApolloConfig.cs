using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Domain.Observers;
using Apollo.Analytics.Data;
using Apollo.Analytics.Abstractions.Data;
using Apollo.Analytics.Data.Mongo;

namespace Apollo.Analytics.Domain
{
    public class ApolloConfig
    {
        public static ApolloConfig Instance { get; private set; }
        static ApolloConfig()
        {
            Instance = new ApolloConfig();
        }

        private ApolloConfig()
        {

        }

        public void OnStartup()
        {
            string dbName = "Apollo_Testing";

            IUserRepository userRepo = new MongoUserRepository(dbName);
            IPageRepository pageRepo = new MongoPageRepository(dbName);
            

            ApolloEngine.Instance.Config(
                new List<IEngineObserver>() { 
                    //new UserObserver(userRepo), 
                    //new TopPagesObserver(pageRepo), 
                    new ZeusObserver()
                    //new In
                    new ApolloFinalizer(userRepo) },
                userRepo
                );
        }
    }
}
