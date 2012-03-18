using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Apollo.Analytics.Abstractions;
using Zeus.Domain;

namespace Apollo.Analytics.Domain
{
    public class EngineObserverData
    {
        public HttpContext Context { get; set; }
        public IApolloUser User { get; set; }
        public Dictionary<string, object> FinalData { get; set; }
        public IEnumerable<IZeusCommand> Commands { get; set; }
    }
}
