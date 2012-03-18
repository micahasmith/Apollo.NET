using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo.Analytics.Abstractions
{
    public interface IApolloPage
    {
         string Id { get; }
         string Url { get; set; }
         int Hits { get; set; }
         DateTime Created { get; set; }
         int Version { get; set; }
    }
}
