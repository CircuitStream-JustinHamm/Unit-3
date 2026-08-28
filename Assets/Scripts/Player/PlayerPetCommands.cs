using System.Collections.Generic;
using UnityEngine;

public class PlayerPetCommands : MonoBehaviour
{
    [SerializeField] Pet pet;
    [SerializeField] Transform cameraPivot;
    [SerializeField] GameObject buildPrefab;
    private bool moveCommandInput;
    private bool buildCommandInput;

    Queue<PetCommand> commands = new Queue<PetCommand>();

    PetCommand currentCommand;

    void Update()
    {
        ProcessCommands();

        if (moveCommandInput)
        {
            IssueMoveCommand();
        }

        if (buildCommandInput)
        {
            IssueBuildCommand();
        }
    }

    private void ProcessCommands()
    {
        bool commandInProgress = currentCommand != null && currentCommand.Finished() == false;
        bool commandsInQueue = commands.Count > 0;

        if(commandInProgress)
        {
            // Debug.Log("Should update command");
            currentCommand.Update();
        }

        if (currentCommand != null && currentCommand.Finished())
        {
            // Debug.Log("Should remove command");
            currentCommand = null;
        }

        else if (commandsInQueue && currentCommand == null)
        {
            // Debug.Log("Should grab next command");
            currentCommand = commands.Dequeue();
            currentCommand.Execute(pet);
        }
    }

    private void IssueMoveCommand()
    {
        commands.Enqueue(new PetMoveCommand(GetMoveTarget()));
    }

    private void IssueBuildCommand()
    {
        commands.Enqueue(new PetBuildCommand(GetMoveTarget(), buildPrefab));
    }

    public Vector3 GetMoveTarget()
    {
        Vector3 moveTarget = transform.position;

        RaycastHit info;
        Ray ray = new Ray(cameraPivot.position, cameraPivot.forward);

        if(Physics.Raycast(ray, out info))
        {
            moveTarget = info.point;
        }

        return moveTarget;
    }

    public void SetMoveCommandInput(bool value)
    { moveCommandInput = value; }

    public void SetBuildCommandInput(bool value)
    { buildCommandInput = value; }
}
