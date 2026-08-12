using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, ISelectable
{
    public UnityEvent onInteract;

    public string GetSelectionText()
    {
        return "";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void OnInteract()
    {
        onInteract?.Invoke();
    }

    public void OnPickup()
    { }

    public void OnPutDown()
    { }

    public bool ShouldPickup()
    {
        return false;
    }
}
