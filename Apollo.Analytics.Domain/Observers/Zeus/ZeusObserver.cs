using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeus.Domain;

namespace Apollo.Analytics.Domain.Observers.Zeus
{
    public class ZeusObserver:IEngineObserver
    {
        private IApolloZeusObserver[] _handlers;
        private int _length;
        public ZeusObserver(IEnumerable<IApolloZeusObserver> handlers)
        {
            if (handlers != null)
            {
                _handlers = handlers.ToArray();
                _length = _handlers.Count();
            }
        }

        public string Name
        {
            get { return "Zeus"; }
        }

        public void OnObserve(EngineObserverData data)
        {
            if (_handlers != null)
            {
                foreach (var c in data.Commands)
                {
                    var h = _handlers.FirstOrDefault(i => i.Command == c.Name);
                    if (h != null)
                    {
                        h.Handle(data);
                    }
                }
            }
        }
    }
}
