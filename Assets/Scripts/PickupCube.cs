using UnityEngine;

public class PickupCube : MonoBehaviour, IGrabbable
{
    new private Rigidbody rigidbody;
    bool wasKinematic;

    private void Start()
    { rigidbody = GetComponent<Rigidbody>(); }

    public void Grab(GrabBehaviour grabber)
    {
        if (rigidbody != null)
        {
            wasKinematic = rigidbody.isKinematic;
            rigidbody.isKinematic = true;
        }
    }

    public void Drop(GrabBehaviour grabber)
    {
        if (rigidbody != null)
        {
            rigidbody.isKinematic = wasKinematic;
        }
    }

    public Transform GetTransform()
    { return transform; }
}
