using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo.Analytics.Abstractions
{
    public interface IApolloUser
    {
        string Id { get; }
        DateTime Created { get; set; }
        DateTime LastHit { get; set;}
        int Version { get; set; }

        Dictionary<string, object> Arguments { get;  }
    }
}
