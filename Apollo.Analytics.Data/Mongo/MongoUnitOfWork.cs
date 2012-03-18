using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using Apollo.Infrastructure;

namespace Apollo.Analytics.Data.Mongo
{
    public class MongoUnitOfWork:IDisposable
    {
        private MongoServer _Server { get; set; }
        public MongoUnitOfWork()
        {
            _Server = MongoServer.Create();
        }
        public MongoServer GetServer()
        {
            return _Server;
        }

        public static MongoUnitOfWork Factory()
        {
            HttpContextCache c = new HttpContextCache();
            return c.Proxy("mongoserver", () =>
            {
                return new MongoUnitOfWork();
            });
            
        }

        public void Dispose()
        {
            _Server.Disconnect();
        }
    }
}
