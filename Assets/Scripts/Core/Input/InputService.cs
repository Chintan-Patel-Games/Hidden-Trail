using UnityEngine;
using HiddenTrail.Core.Input;
using HiddenTrail.Utilities;

namespace HiddenTrail.Core.Services
{
    /// <summary>
    /// Entry point for input. Delegates gesture detection to InputController.
    /// Emits OnSwipeDetected via EventService. Zero gameplay logic here.
    /// </summary>
    public class InputService : MonoBehaviour
    {
        private InputController _controller;
        private bool _ready;

        public void Initialize()
        {
            _controller = new InputController();
            _controller.Initialize(OnSwipeDetected);
            _controller.Enable();
            _ready = true;
        }

        private void OnEnable()
        {
            if (_ready) _controller.Enable();
        }

        private void OnDisable() => _controller?.Disable();

        private void OnSwipeDetected(SwipeDirection direction)
        {
            if (direction == SwipeDirection.None) return;
            GameService.Instance.EventService.OnSwipe.InvokeEvent(direction);
        }
    }
}