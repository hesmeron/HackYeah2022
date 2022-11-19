using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativePlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _sorce;

    [SerializeField] private AudioClip[] _clips;

    private int _index = -1;

    private void Start()
    {
        Progress();
    }

    public void Progress()
    {
        _index++;
        _sorce.clip = _clips[_index];
        _sorce.Play();
    }

}
