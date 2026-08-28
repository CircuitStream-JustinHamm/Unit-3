using UnityEngine;

public abstract class PetCommand
{
    public abstract void Execute(Pet pet);

    public virtual void Update()
    { }

    public abstract bool Finished();
}
