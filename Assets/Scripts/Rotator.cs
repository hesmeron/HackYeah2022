using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Animator _animattor;

    public void Rotate()
    {
        _animattor.SetTrigger("Turn");
    }
}

