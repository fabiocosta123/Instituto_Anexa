using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexa.Domain
{
    public static class DomainEvents
    {
        private static readonly List<Delegate> _handlers = new();

        public static void Register<T>(Action<T> callback)
        {
            _handlers.Add(callback);
        }

        public static void Raise<T>(T domainEvent)
        {
            foreach (var handler in _handlers.OfType<Action<T>>())
            {
                handler(domainEvent);
            }
        }
    }
}
