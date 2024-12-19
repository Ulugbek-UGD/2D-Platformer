using UnityEngine.InputSystem;
using UnityEngine;

namespace RedwoodTestTask
{
    [DefaultExecutionOrder(-1)]
    public class PlayerInputs : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActions;
        
        private InputActionMap actionMap;
        
        public static InputAction Move { get; private set; }
        public static InputAction Fire { get; private set; }
        
        //============================================================
        private void Awake()
        {
            FindInputActions();
        }
        //============================================================
        private void OnEnable()
        {
            EnableInputs();
        }
        //============================================================
        private void OnDisable()
        {
            DisableInputs();
        }
        //============================================================
        private void FindInputActions()
        {
            actionMap = inputActions.FindActionMap("Player");
            
            Move = actionMap.FindAction("Move");
            Fire = actionMap.FindAction("Fire");
        }
        //============================================================
        private void EnableInputs()
        {
            actionMap.Enable();
        }
        //============================================================
        private void DisableInputs()
        {
            actionMap.Disable();
        }
        //============================================================
    }
}