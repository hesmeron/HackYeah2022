using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRPlayerAvatar : MonoBehaviour
{
    [SerializeField] 
    private PlayerInput _playerInput;

    private Vector2 _movementValue;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_movementValue.x, 0, _movementValue.y) * Time.deltaTime;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movementValue = context.ReadValue<Vector2>();
    }
}
