using HiddenTrail.Core.Events.Controller;
using System;

namespace HiddenTrail.Core.Events.Service
{
    public class EventService
    {
        public EventController<Enum> OnSwipe { get; private set; }

        public EventService()
        {
            OnSwipe = new EventController<Enum>();
        }
    }
}