using UnityEngine;

public class GrabBehaviour : Interactor
{
    [SerializeField] private Transform pickupPivot;
    private IGrabbable grabbedObject;

    protected override void Update()
    {
        if (grabbedObject == null)
        { base.Update(); }

        else if (ShouldDropObject())
        { DropObject(); }
    }

    protected override void Interact()
    {
        if (interactInput)
        {
            grabbedObject = info.transform.GetComponent<IGrabbable>();
            if (grabbedObject != null)
            {
                grabbedObject.Grab(this);
                grabbedObject.GetTransform().SetParent(pickupPivot);
                grabbedObject.GetTransform().localPosition = Vector3.zero;
                grabbedObject.GetTransform().localRotation = Quaternion.identity;
            }
        }
    }

    private bool ShouldDropObject()
    { return interactInput; }

    private void DropObject()
    {
        grabbedObject.Drop(this);
        grabbedObject.GetTransform().SetParent(null);
        grabbedObject = null;
    }
}