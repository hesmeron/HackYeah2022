using System;
using UnityEngine;

public enum GripState{
    Idle,
    Grab,
    Forward
}
[System.Serializable]
public class GripBehaviour : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private GrabSystem _grabSystem;
    [SerializeField] private GameObject _take, _free;

    public GripState _gripState;

    public void Update()
    {
        switch (_gripState)
        {
            case GripState.Idle:
                _renderer.enabled = false;
                _take.SetActive(false);
                _free.SetActive(true);
                break;
            case GripState.Grab:
                _take.SetActive(true);
                _free.SetActive(false);
                TryGrab();
                break;
            case GripState.Forward:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    public void SetGripState(GripState gripState)
    {
        switch (gripState)
        {
            case GripState.Idle:
                _gripState = GripState.Idle;
                break;
            case GripState.Grab:
                _gripState = GripState.Grab;
                break;
            case GripState.Forward:
                if (_gripState == GripState.Grab)
                {
                    _gripState = GripState.Forward;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gripState), gripState, null);
        }
    }


    bool TryGrab()
    {
        Vector3 origin = transform.position;
        if (_grabSystem.HasTarget())
        {
            _renderer.enabled = false;
            return false;
        }
        if (Physics.Raycast(new Ray(origin, transform.forward), out RaycastHit hit))
        {
            _renderer.enabled = true;
            Vector3[] positions = new[] {transform.position, hit.point};
            _renderer.SetPositions(positions);
            if (hit.transform.gameObject.TryGetComponent(out InteractiveBehaviour interactive))
            {
                _grabSystem.SetTarget(interactive, this);
                return true;
            }
        }
        return false;
    }
    
    
    
}
