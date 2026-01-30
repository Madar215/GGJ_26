using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input {
    [CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
    public class InputReader : ScriptableObject, PlayerInputActions.IPlayer1Actions {
        // ---- Events
        // P1
        public event UnityAction P1TopLeft = delegate { };
        public event UnityAction P1TopCenter = delegate { };
        public event UnityAction P1TopRight = delegate { };
        public event UnityAction P1BottomLeft = delegate { };
        public event UnityAction P1BottomCenter = delegate { };
        public event UnityAction P1BottomRight = delegate { };
        // P2
        public event UnityAction P2TopLeft = delegate { };
        public event UnityAction P2TopCenter = delegate { };
        public event UnityAction P2TopRight = delegate { };
        public event UnityAction P2BottomLeft = delegate { };
        public event UnityAction P2BottomCenter = delegate { };
        public event UnityAction P2BottomRight = delegate { };
    
    
        private PlayerInputActions _inputActions;

        private void OnEnable() {
            if (_inputActions == null) {
                _inputActions = new PlayerInputActions();
                _inputActions.Player1.SetCallbacks(this);
            }

            EnablePlayerActions();
        }

        private void OnDisable() {
            DisablePlayerActions();
        }
    
        private void EnablePlayerActions() {
            _inputActions.Enable();
        }

        private void DisablePlayerActions() {
            _inputActions.Disable();
        }
    
        public void OnP1TopLeft(InputAction.CallbackContext context) {
            P1TopLeft?.Invoke();
        }

        public void OnP2TopLeft(InputAction.CallbackContext context) {
            P2TopLeft?.Invoke();
        }

        public void OnP1TopCenter(InputAction.CallbackContext context) {
            P1TopCenter?.Invoke();
        }

        public void OnP2TopCenter(InputAction.CallbackContext context) {
            P2TopCenter?.Invoke();
        }

        public void OnP1TopRight(InputAction.CallbackContext context) {
            P1TopRight?.Invoke();
        }

        public void OnP2TopRight(InputAction.CallbackContext context) {
            P2TopRight?.Invoke();
        }

        public void OnP1BottomLeft(InputAction.CallbackContext context) {
            P1BottomLeft?.Invoke();
        }

        public void OnP2BottomLeft(InputAction.CallbackContext context) {
            P2BottomLeft?.Invoke();
        }

        public void OnP1BottomCenter(InputAction.CallbackContext context) {
            P1BottomCenter?.Invoke();
        }

        public void OnP2BottomCenter(InputAction.CallbackContext context) {
            P2BottomCenter?.Invoke();
        }

        public void OnP1BottomRight(InputAction.CallbackContext context) {
            P1BottomRight?.Invoke();
        }

        public void OnP2BottomRight(InputAction.CallbackContext context) {
            P2BottomRight?.Invoke();
        }
    }
}
