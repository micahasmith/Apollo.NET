using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Apollo.Analytics.Data;
using Apollo.Analytics.Abstractions.Data;
using Apollo.Analytics.Abstractions;
using Apollo.Infrastructure;

namespace Apollo.Analytics.Domain
{
    public class ApolloEngine
    {
        public static ApolloEngine Instance { get; private set; }
        private int _Length;
        static ApolloEngine()
        {
            Instance = new ApolloEngine();
        }


        private IEngineObserver[] _Observers;
        private ApolloUserFactory _UserFactory;
        private ApolloEngine()
        {
            
        }
        public void Config(IEnumerable<IEngineObserver> observers,IUserRepository userRepo)
        {
            _Observers = observers.ToArray();
            _Length = _Observers.Length;
            _UserFactory = new ApolloUserFactory(userRepo);
        }
        public void Handle(HttpContext context)
        {
            int i = 0;
            try
            {
                EngineObserverData data = new EngineObserverData()
                {
                    User = _UserFactory.Create(context),
                    FinalData = new Dictionary<string, object>(),
                    Context = context,
                    Commands = Zeus.Domain.ZeusParser.ParseUrl(context.Request.Url.ToString())
                };

                
                for (; i < _Length; i += 1)
                {
                    try
                    {
                        _Observers[i].OnObserve(data);
                    }
                    catch (Exception exc)
                    {
                        throw new Exception(string.Format("Engine error on {0}", _Observers[i].Name), exc);
                    }
                }
            }
            finally
            {
                HttpContextCache.CacheDispose();

            }
        }
    }
}
