using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _grabSound;
    [SerializeField] private AudioSource _ambient;
    [SerializeField]
    private Transform  _hmd;

    [SerializeField] private TMP_Text _angleText;
    [SerializeField] 
    private GripBehaviour _left, _right;

    private InteractiveBehaviour _target;

    public bool HasTarget() => _target != null;

    void Update()
    {
        bool leftGrab = _left._gripState == GripState.Grab;
        bool rightGrab = _right._gripState == GripState.Grab;

        bool enabledAmbient = false;
        if( leftGrab || rightGrab)
        {
            AdjustPosition();
        }
        else if(_left._gripState == GripState.Idle && _right._gripState == GripState.Idle)
        {
            Drop();
        }
        else if(_left._gripState == GripState.Forward && _right._gripState == GripState.Forward)
        {
            enabledAmbient = true;
            AdjustPositionForward();
        }

        _ambient.enabled = enabledAmbient;
    }
    
    private void AdjustPosition()
    {
        bool leftGrab = _left._gripState == GripState.Grab;
        bool rightGrab = _right._gripState == GripState.Grab;
        Vector3 targetPosition = Vector3.zero;
        if(leftGrab && !rightGrab)
        {
            targetPosition = _left.transform.position;
        }
        if(!leftGrab && rightGrab)
        {
            targetPosition = _right.transform.position;
        }

        if (leftGrab && rightGrab)
        {
            targetPosition = (_left.transform.position + _right.transform.position)/2f;
        }
        
        float angle = Vector2.Angle(Vector3.up, _right.transform.position - _left.transform.position);
        _angleText.text = angle.ToString();
        _target.InteractWithRotation(angle);
        _target.InteractWithPosition(targetPosition);
    }

    private void AdjustPositionForward()
    {
        Vector3 dir = _hmd.transform.forward;
        _target.InteractWithVector(dir * Time.deltaTime *8f);
    }

    
    public void SetTarget(InteractiveBehaviour target)
    {
        _target = target;
        _target.Grab();
        _source.PlayOneShot(_grabSound);
    }
    
    private void Drop()
    {
        if (_target)
        {
            _target.Drop();
            _target = null;
        }
    }
}