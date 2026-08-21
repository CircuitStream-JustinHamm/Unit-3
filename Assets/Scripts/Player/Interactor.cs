using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] new private Transform camera;
    [SerializeField] private float interactionDistance;

    protected RaycastHit info;
    protected bool interactInput;

    protected virtual void Update()
    {
        if (HitObject())
            Interact();
    }

    protected virtual void Interact()
    {
        if(interactInput)
        {
            IInteractable target = info.transform.GetComponent<IInteractable>();
            if (target != null)
            {
                target.Interact(this);
            }
        }
    }

    public bool HitObject()
    {
        Ray interactionRay = new Ray(camera.position, camera.forward);
        return Physics.Raycast(interactionRay, out info, interactionDistance, LayerMask.GetMask("Selectable"));
    }

    public void SetInteractInput(bool value)
    { interactInput = value; }
}