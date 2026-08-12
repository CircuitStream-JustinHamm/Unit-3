using UnityEngine;

public class PickupCube : MonoBehaviour, ISelectable
{
    new private Rigidbody rigidbody;
    bool wasKinematic;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public bool ShouldPickup()
    {
        return true;
    }

    public void OnInteract()
    { }

    public void OnPickup()
    {
        if (rigidbody != null)
        {
            wasKinematic = rigidbody.isKinematic;
            rigidbody.isKinematic = true;
        }
    }

    public void OnPutDown()
    {
        if (rigidbody != null)
        {
            rigidbody.isKinematic = wasKinematic;
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public string GetSelectionText()
    {
        return "";
    }
}
