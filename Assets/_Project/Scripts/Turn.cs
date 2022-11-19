using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField]
    InteractiveWheel _wheel;

    [SerializeField] 
    private Transform _platformPivot;

    [SerializeField] private float _speed = 10f;
    
    private void Awake()
    {
        _wheel.onTurn += WheelOnTurn;
    }

    private void WheelOnTurn(float angle)
    {
        _platformPivot.Rotate(0f, angle * _speed, 0f);
    }
}
