using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, IInteractable
{
    public UnityEvent onInteract;

    public void Interact(Interactor interactor)
    { onInteract?.Invoke(); }
}
