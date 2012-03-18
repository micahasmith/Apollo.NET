using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Apollo.Analytics.Abstractions;
using ServiceStack.Text;
using Apollo.Infrastructure;
using Apollo.Analytics.Abstractions.Data;

namespace Apollo.Analytics.Domain
{
    public class ApolloFinalizer:IEngineObserver
    {
        public string  Name
        {
            get { return "Finalizer"; }
        }

        IUserRepository _userdb;
        public ApolloFinalizer(IUserRepository userdb)
        {
            _userdb = userdb;
        }
        public void OnObserve(EngineObserverData data)
        {

                //var data = new Data(){User=user};
                data.FinalData.Add("user", _userdb.Get(data.User.Id));
                var u = string.Format("{0}({1});"
                    , data.Context.Request["callback"]
                    , JsonSerializer.SerializeToString<Dictionary<string, object>>(data.FinalData));


                data.Context.Response.Write(u);



        }

        //private class Data
        //{
        //    public IApolloUser User { get; set; }
        //    public Dictionary<string, string> Others { get; set; }
        //}
    }
}
