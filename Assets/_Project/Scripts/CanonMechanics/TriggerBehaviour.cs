using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerBehaviour : InteractiveBehaviour
{
    public event Action onTriggerReleased;
    [SerializeField]
    private float _chargeSpeed;

    private Vector3 _restPosition;
    private float _currentPower = 0;
    private bool _released = false;
    private bool _first = true;
    private void Awake()
    {
        _restPosition = transform.position;
    }

    public override void Grab(GripBehaviour gripBehaviour)
    {
        transform.position = gripBehaviour.transform.position;
        _first = true;
    }

    public override void InteractWithPosition(Vector3 position)
    {
        if (_first)
        {
            transform.position = position;
            _first = false;
        }
        else
        {
            float distance = Vector3.Distance(position, transform.position);
            _currentPower += (distance / (Time.deltaTime * Time.deltaTime * 100)) * _chargeSpeed;
            if (_currentPower > 1f &&  Vector3.Distance(_restPosition, transform.position) > 0.5f)
            {
                Release();
            }
            transform.position = position;
        }

    }

    public override bool Break()
    {
        if (_released)
        {
            _released = false;
            return true;
        }
        else
        {
            return false;
        }

    }

    public override void Drop()
    {
        transform.position = _restPosition;
        _currentPower = 0f;
    }

    private void Release()
    {
        if (!_released)
        {
            onTriggerReleased?.Invoke();
            _released = true;
        }
    }
}
