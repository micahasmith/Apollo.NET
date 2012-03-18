using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Data;
using System.Net;
using System.Web;
using Apollo.Analytics.Abstractions.Data;
using Apollo.Analytics.Abstractions;

namespace Apollo.Analytics.Domain
{
    public class ApolloUserFactory
    {
        public IUserRepository _db;
        private static string _Id ="EFD8A92B";

        public ApolloUserFactory(IUserRepository db)
        {
            _db = db;
        }

        public IApolloUser  Create(System.Web.HttpContext context)
        {
            var req = context.Request;
            var ac=req.Cookies["apollo"];
            IApolloUser user;
            if (ac == null)
            {
                return CreateUser(context);
            }
            else
            {
                user = _db.Get(ac[_Id]);
                _db.HeartBeat(ac[_Id]);
                if (user == null)
                    user= CreateUser(context);
                return user;
            }
        }

        private IApolloUser CreateUser(HttpContext c)
        {
            var user = _db.Create();
            var ck = c.Request.Cookies["apollo"];
           
            if (ck == null)
            {
                ck = new HttpCookie("apollo");
                ck.Expires = DateTime.MaxValue;
                ck[_Id] = user.Id;
                c.Response.Cookies.Add(ck);
            }
            else
                c.Response.Cookies["apollo"][_Id] = user.Id;

 
            return user;
        }
    }
}
