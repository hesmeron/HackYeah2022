using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CanonHeight : MonoBehaviour
{
    [SerializeField]
    InteractiveWheel _wheel;

    [SerializeField] 
    private float _high;
    [SerializeField]
    private float _low;

    [SerializeField]
    private float _speed = 1f;

    [SerializeField]
    [ReadOnly]
    private float value = 0f;
    void Awake()
    {
        _wheel.onTurn += WheelOnTurn;
    }

    [Button]
    private void WheelOnTurn(float angle)
    {
        float increase = angle * _speed;
        value += increase;
        value = Mathf.Clamp01(value);
        float y = (_low * (1-value)) +(_high * value);
        transform.forward = new Vector3(transform.forward.x,y,transform.forward.z );
    }
}
