using HiddenTrail.Core.Events.Service;
using HiddenTrail.Utilities;
using UnityEngine;

namespace HiddenTrail.Core.Services
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [SerializeField] private InputService _inputService;
        public InputService InputService => _inputService;

        public EventService EventService { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            InitializeServices();
        }

        private void InitializeServices()
        {
            EventService = new EventService();
            _inputService.Initialize();
        }
    }
}