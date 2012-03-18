using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo.Analytics.Domain.Observers.Zeus
{
    public interface IApolloZeusObserver
    {
        string Command { get; set; }
        public void Handle(EngineObserverData data);
    }
}
