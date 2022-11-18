using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabState : InteractionState
{
    private Grabable _target;
    private GripBehaviour _left, _right;
    public GrabState(GrabSystem grabSystem) : base(grabSystem)
    {
    }

    public override void OnEnter()
    {
        
    }

    public override void OnUpdate()
    {
        Vector3 targetPosition = (_left.transform.position + _right.transform.position)/2f;
        float x = Mathf.Lerp(_target.transform.position.x, targetPosition.x, Time.deltaTime * 4f);
        float y = Mathf.Lerp(_target.transform.position.y, targetPosition.y, Time.deltaTime * 4f);
        float z = Mathf.Lerp(_target.transform.position.z, targetPosition.z, Time.deltaTime * 4f);
        _target.transform.position = new Vector3(x, y, z);
    }
}
