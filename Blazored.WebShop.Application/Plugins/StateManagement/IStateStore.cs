using System;
using System.Collections.Generic;
using System.Text;

namespace Blazored.WebShop.Application.Plugins.StateManagement
{
    public interface IStateStore
    {
        void AddStateChangeListeners(Action listener);
        void RemoveStateChangeListeners(Action listener);
        void BroadcastStateChange();
    }
}
