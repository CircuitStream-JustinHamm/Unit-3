using UnityEngine;

public class HighlightBehaviour : Interactor
{
    IHighlightable target;

    protected override void Interact()
    {
        IHighlightable newTarget = info.transform.GetComponent<IHighlightable>();
        if(target != newTarget)
        {
            if(target != null)
            {
                target.StopHighlight(this);
            }
            target = newTarget;
            target?.StartHighlight(this);
        }
    }
}