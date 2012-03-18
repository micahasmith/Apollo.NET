using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo.Analytics.Abstractions
{
    public interface IApolloInteraction
    {
        string UserId { get; set; }
        string PageId { get; set; }
        string Code { get; set; }
        DateTime Created { get; set; }
        Dictionary<string, object> Arguments { get;  }
    }
}
