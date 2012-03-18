using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Data;
using Apollo.Analytics.Abstractions;
using Apollo.Analytics.Abstractions.Data;
using Zeus.Domain;

namespace Apollo.Analytics.Domain.Observers
{
    public class UserObserver:IEngineObserver
    {
        public IUserRepository _db;

        public UserObserver(IUserRepository db)
        {
            _db = db;
        }

        public string Name
        {
            get { return "UserInit"; }
        }

        public void OnObserve(EngineObserverData data)
        {
            HandleZeusCommands(data);
            //data.FinalData.Add("user", data.User);
        }
        private void HandleZeusCommands(EngineObserverData data)
        {
            IEnumerable<IZeusCommand> commands = data.Commands;
            if (commands != null)
            {
                foreach (var c in commands)
                {
                    switch (c.Name)
                    {
                        case ApolloZeusCommands.PushUserArguments:
                            PushUserArguments(data.User,c.Arguments);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void PushUserArguments(IApolloUser user,Dictionary<string,string> args)
        {
            Dictionary<string,object> d = new Dictionary<string,object>();
            foreach(var k in args.Keys)
            {
                d.Add(k,args[k]);
            }
            _db.PushArguments(user.Id, d);
        }
    }
}
