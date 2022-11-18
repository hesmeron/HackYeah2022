using UnityEngine;

public abstract  class InteractiveBehaviour : MonoBehaviour
{
    public abstract void Grab();
    public abstract void InteractWithRotation(float angle);
    public abstract void InteractWithPosition(Vector3 position);

    public abstract void InteractWithVector(Vector3 vector);
    public abstract void Drop();
}
