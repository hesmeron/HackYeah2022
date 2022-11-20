using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class XRRig : MonoBehaviour
{
    [SerializeField] 
    private InputActionMap _inputActionMap;
    
    [SerializeField] 
    private InputAction _handLeftPosition;
    
    [SerializeField] private Transform _head;

    void Start()
    {
        _inputActionMap.FindAction("HeadPosition").performed += HeadOnperformed; 
        _inputActionMap.FindAction("HeadRotation").performed += HeadRotationOnperformed; 
    }


    private void OnEnable()
    {
        _handLeftPosition.Enable();
        _inputActionMap.Enable();
    }

    private void HeadOnperformed(InputAction.CallbackContext context)
    {
        _head.transform.localPosition = context.ReadValue<Vector3>();
    }
    private void HeadRotationOnperformed(InputAction.CallbackContext context)
    {
        _head.transform.localRotation = context.ReadValue<Quaternion>();
    }
}
