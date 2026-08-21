using UnityEngine;

public interface IGrabbable
{
    public void Grab(GrabBehaviour pickup);
    public void Drop(GrabBehaviour pickup);

    public Transform GetTransform();
}