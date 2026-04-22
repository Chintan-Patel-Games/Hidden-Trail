using HiddenTrail.Core.Events.Service;
using UnityEngine;

namespace HiddenTrail.Core.Services
{
    public class GameService : MonoBehaviour
    {
        private EventService _eventService;

        private void Awake()
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            // Init order matters later
            Debug.Log("GameService Initialized");
        }
    }
}