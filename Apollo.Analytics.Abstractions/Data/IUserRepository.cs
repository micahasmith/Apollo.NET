using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Abstractions;

namespace Apollo.Analytics.Abstractions.Data
{
    public interface IUserRepository
    {
        IApolloUser Get(string id);
        IApolloUser Create();
        void HeartBeat(string id);
        void PushArguments(string userid,Dictionary<string, object> args);
    }
}
