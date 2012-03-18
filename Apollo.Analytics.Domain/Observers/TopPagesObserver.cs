using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Abstractions.Data;
using Apollo.Analytics.Data;

namespace Apollo.Analytics.Domain.Observers
{
    public class TopPagesObserver:IEngineObserver
    {
        private int _Number;
        private IPageRepository _db;

        public TopPagesObserver(IPageRepository pageRepo,int num)
        {
            _Number = num;
            _db = pageRepo;
        }
        public TopPagesObserver(IPageRepository pageRepo):this(pageRepo,20)
        {

        }


        public string Name
        {
            get { return "TopPages"; }
        }

        public void OnObserve(EngineObserverData data)
        {
            var context = data.Context;
            if (context.Request.UrlReferrer != null)
            {
                var url = context.Request.UrlReferrer.AbsoluteUri;

                _db.RegisterHit(url);
            }
            var top=_db.GetTopPages(_Number);

            data.FinalData.Add("top_pages",top.ToArray() );
            
        }
    }
}
