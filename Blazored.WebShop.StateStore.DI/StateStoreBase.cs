using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.StateManagement;

namespace Blazored.WebShop.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action Listeners;

        public void AddStateChangeListeners(Action listener) => Listeners += listener;

        public void RemoveStateChangeListeners(Action listener) => Listeners -= listener;

        public void BroadcastStateChange() => Listeners?.Invoke();
    }
}
