using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private Transform _pivot;
    
    [SerializeField]
    private float _currentSpeed = 2f;
    [SerializeField]
    
    private float _downwardSpeed = 0f;

    [SerializeField]
    private float _slowDownSpeed = 0.25f;


    private Vector3 _startForward;

    void Start()
    {
        _startForward = transform.forward;
    }
    void Update()
    {
        _currentSpeed *= 1 - (_slowDownSpeed* Time.deltaTime);
        _downwardSpeed += 1 * Time.deltaTime;

        Vector3 horizontal = (_startForward * _currentSpeed);
        Vector3 vertical = (-Vector3.up * _downwardSpeed);
        var position = transform.position;
        Vector3 newPosition = position + ((horizontal + vertical) * Time.deltaTime);
        transform.forward = newPosition - position;
        transform.position = newPosition;
    }
}
