using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Apollo.Analytics.Abstractions;

namespace Apollo.Analytics.Domain
{
    public interface IEngineObserver
    {
        string Name { get; }
        void OnObserve(EngineObserverData data);
    }
}
