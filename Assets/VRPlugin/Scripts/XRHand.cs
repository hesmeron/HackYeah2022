using UnityEngine;
using UnityEngine.InputSystem;

public class XRHand : MonoBehaviour
{
    [SerializeField] 
    private InputActionMap _inputActionMap;
    
    [SerializeField] 
    private GripBehaviour _gripBehaviour;

    void Start()
    {
        _inputActionMap.FindAction("Grab").performed += GrabOnPerformed;
        _inputActionMap.FindAction("Grab").canceled += GrabOnCanceled;
        _inputActionMap.FindAction("Forward").canceled += ForwardOnCanceled;
        _inputActionMap.FindAction("Forward").performed += ForwardOnPerformed;
    }

    private void GrabOnPerformed(InputAction.CallbackContext obj)
    {
        _gripBehaviour.SetGripState(GripState.Grab);
    }
    private void GrabOnCanceled(InputAction.CallbackContext obj)
    {
        _gripBehaviour.SetGripState(GripState.Idle);
    }
    
    private void ForwardOnPerformed(InputAction.CallbackContext obj)
    {
        _gripBehaviour.SetGripState(GripState.Forward);
    }
    
    private void ForwardOnCanceled(InputAction.CallbackContext obj)
    {
        _gripBehaviour.SetGripState(GripState.Idle);
    }

    private void OnEnable()
    {
        _inputActionMap.Enable();
    }
}

