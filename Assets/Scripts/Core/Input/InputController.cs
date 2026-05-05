using System;
using UnityEngine;
using UnityEngine.InputSystem;
using HiddenTrail.Utilities;

namespace HiddenTrail.Core.Input
{
    /// <summary>
    /// Owns HiddenTrailInputActions (generated C# wrapper).
    /// Reads touch/pointer, classifies swipe, reports via callback.
    /// Pure C# — no MonoBehaviour.
    /// </summary>
    public class InputController
    {
        private HiddenTrailInputActions _actions; // generated wrapper
        private Action<SwipeDirection> _onSwipe;

        private Vector2 _startPos;
        private float _startTime;

        // ── Init ───────────────────────────────────────────

        public void Initialize(Action<SwipeDirection> onSwipe)
        {
            _onSwipe = onSwipe;
            _actions = new HiddenTrailInputActions();
            BindActions();
        }

        public void Enable() => _actions.Enable();
        public void Disable() => _actions.Disable();

        // ── Binding ────────────────────────────────────────

        private void BindActions()
        {
             _actions.Gameplay.TouchPress.started  += OnTouchStart;
            _actions.Gameplay.TouchPress.canceled += OnTouchEnd;
        }

        private void OnTouchStart(InputAction.CallbackContext ctx)
        {
             _startPos  = _actions.Gameplay.TouchPosition.ReadValue<Vector2>();
            _startTime = Time.time;
        }

        private void OnTouchEnd(InputAction.CallbackContext ctx)
        {
            Vector2 currentPos = _actions.Gameplay.TouchPosition.ReadValue<Vector2>();
            if (Time.time - _startTime > Constants.SwipeTimeLimit) return;
            Vector2 delta = currentPos - _startPos;
            _onSwipe?.Invoke(ClassifySwipe(delta));
            Debug.Log("Swipe: " + ClassifySwipe(delta));
        }

        // ── Helpers ────────────────────────────────────────

        private SwipeDirection ClassifySwipe(Vector2 delta)
        {
            if (delta.magnitude < Constants.SwipeThreshold)
                return SwipeDirection.None;

            return Mathf.Abs(delta.x) > Mathf.Abs(delta.y)
                ? (delta.x > 0 ? SwipeDirection.Right : SwipeDirection.Left)
                : (delta.y > 0 ? SwipeDirection.Up : SwipeDirection.Down);
        }
    }
}