using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InteractiveWheel : InteractiveBehaviour
{
    public event Action<float> onTurn;
    [SerializeField]
    private Transform _movingPart;

    [SerializeField] private Transform _testPivot;

    [SerializeField]
    private float _previousAngle = 0f;

    [SerializeField] private float _compundAngle = 0f;

    private void OnDrawGizmos()
    {
        InteractWithPosition(_testPivot.transform.position);
    }

    public override void Grab(GripBehaviour gripBehaviour)
    {
        
    }
    
    public override void InteractWithPosition(Vector3 position)
    {
        Vector3 raw = transform.InverseTransformPoint(position);
        Vector3 localEuler = transform.localRotation.eulerAngles;
        Vector3 newForward = new Vector3(raw.x, 0, raw.z);
        float angle = Vector3.SignedAngle(newForward, _movingPart.forward, transform.up);
        float turn = angle;
        onTurn?.Invoke(turn);
        Debug.Log("Turn " + turn);
        _previousAngle = angle;
        _compundAngle += turn;
        // float angle = Vector2.Angle(new Vector2(localEuler.x, localEuler.z), )
        //transform.forward = transform.TransformPoint(-new Vector3(raw.x, 0, raw.z)).normalized;
        _movingPart.forward = newForward; //transform.TransformPoint();
    }

    [Button]
    public void TurnToPivot()
    {
        InteractWithPosition(_testPivot.transform.position);
    }
    
}
