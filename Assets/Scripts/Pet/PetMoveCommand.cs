using UnityEngine;

public class PetMoveCommand : PetCommand
{
    public Vector3 destination;

    private Pet pet;

    public PetMoveCommand(Vector3 destination)
    {
        this.destination = destination;
    }

    public override void Execute(Pet target)
    {
        pet = target;
        target.agent.SetDestination(destination);
    }

    public override bool Finished()
    {
        bool finished = Vector3.Distance(pet.transform.position, destination) < 0.6f;
        return finished;
    }
}