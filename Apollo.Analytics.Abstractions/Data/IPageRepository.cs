using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo.Analytics.Abstractions;

namespace Apollo.Analytics.Abstractions.Data
{
    public interface IPageRepository
    {
        void RegisterHit(string url);
        IEnumerable<IApolloPage> GetTopPages(int num);
    }
}
