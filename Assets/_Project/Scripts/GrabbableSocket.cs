using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GrabbableSocket : MonoBehaviour
{
    [SerializeField] 
    private MeshRenderer _renderer;
    
    private Material _material;
    [CanBeNull] private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    private void Start()
    {
        _material = new Material(_renderer.material);
        _renderer.material = _material;
    }

    void OnCollisionEnter(Collision col)
    {
        _rigidbodies.Add(col.rigidbody);
        _material.color = Color.green;
    }
    void OnCollisionExit(Collision col)
    {
        _rigidbodies.Remove(col.rigidbody);
        if (_rigidbodies.Count == 0)
        {
            _material.color = Color.red;
        }
    }

    public bool IsBlocked()
    {
        return _rigidbodies.Count > 0;
    }
}
