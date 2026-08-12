using UnityEngine;

public interface ISelectable
{
    bool ShouldPickup();
    void OnInteract();

    void OnPickup();
    void OnPutDown();

    Transform GetTransform();

    string GetSelectionText();
}
