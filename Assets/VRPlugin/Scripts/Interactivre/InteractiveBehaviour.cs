using UnityEngine;

public abstract  class InteractiveBehaviour : MonoBehaviour
{
    
    public virtual void Grab(GripBehaviour gripBehaviour)
    {
    }

    public virtual void InteractWithRotation(float angle){}
    public virtual void InteractWithPosition(Vector3 position){}

    public virtual void InteractWithVector(Vector3 vector){}
    public virtual void Drop(){}

    public virtual bool Break()
    {
        return false;
    }
}
