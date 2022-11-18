using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// This class updates camera position based on HMD position
/// </summary>
public class VRHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void UpdateCameraPosition()
    {
        if (GetXRSubsystems(out List<XRInputSubsystem> subsystems))
        {
            foreach (var subsystem in subsystems)
            {
                subsystem.trackingOriginUpdated += SubsystemOnTrackingOriginUpdated;
            }
        }
    }

    private void SubsystemOnTrackingOriginUpdated(XRInputSubsystem obj)
    {
        throw new System.NotImplementedException();
    }

    private bool GetXRSubsystems(out List<XRInputSubsystem> subsystems)
    {
        subsystems = new List<XRInputSubsystem>();
        SubsystemManager.GetInstances<XRInputSubsystem>(subsystems);
        return subsystems.Count > 0;
    }
}
