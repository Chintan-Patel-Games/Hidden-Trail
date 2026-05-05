using System;

namespace HiddenTrail.Core.Events.Controller
{
    public class EventController<T>
    {
        private event Action<T> listeners = delegate { };

        public void AddListener(Action<T> listener) => listeners += listener;
        public void RemoveListener(Action<T> listener) => listeners -= listener;
        public void InvokeEvent(T arg) => listeners.Invoke(arg);
    }
}