using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSwitch : InteractiveBehaviour
{
    [SerializeField]
    private AudioSource _source;

    [SerializeField] private AudioClip _intro;
    private bool _introPassed = false;
    private float delay = 2f;
    private bool _stoppedTime = false;

    private void Start()
    {
        _stoppedTime = false;
    }

    public override void Grab(GripBehaviour gripBehaviour)
    {
        _source.Stop();
        Time.timeScale = 1f;
        _introPassed = true;
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0 && !_stoppedTime)
        {
            Time.timeScale = 0f;
            _stoppedTime = true;
        }
        if (!_source.isPlaying)
        {
            if (!_introPassed)
            {
                _source.clip = _intro;
                _source.Play();
                Time.timeScale= 1f;
                _introPassed = true;
            }
            
        }
    }
}
