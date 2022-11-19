using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionStates
{
    Grab,
    Forward,
}
public abstract class InteractionState
{
    protected GrabSystem _grabSystem;
    public InteractionState(GrabSystem grabSystem)
    {
        _grabSystem = grabSystem;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
}
