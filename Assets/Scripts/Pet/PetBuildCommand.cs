using UnityEngine;

public class PetBuildCommand : PetCommand
{
    public Vector3 destination;
    public GameObject prefab;

    private Pet pet;

    private bool built = false;

    public PetBuildCommand(Vector3 destination, GameObject objectToBuild)
    {
        this.destination = destination;
        this.prefab = objectToBuild;
    }

    public override void Execute(Pet target)
    {
        pet = target;
        target.agent.SetDestination(destination);
    }

    public override bool Finished()
    {
        bool finished = Vector3.Distance(pet.transform.position, destination) < 0.6f;
        if (finished && built == false)
        {
            GameObject.Instantiate(prefab, destination, Quaternion.identity);
            built = true;
        }
        return finished;
    }
}