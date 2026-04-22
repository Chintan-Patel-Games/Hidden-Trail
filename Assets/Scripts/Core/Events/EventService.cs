using HiddenTrail.Core.Events.Controller;

namespace HiddenTrail.Core.Events.Service
{
    public class EventService
    {
        public EventController PlayerSwipeInput { get; private set; } // For example

        public EventService()
        {
            PlayerSwipeInput = new EventController();
        }
    }
}