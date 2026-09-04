using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterControllerMovement : PlayerMovementBehaviour
{
    private CharacterController controller;

    private void Start()
    { controller = GetComponent<CharacterController>(); }

    protected override void ApplyMovement(Vector3 movementVector)
    {
        movementVector += Physics.gravity;
        controller.Move(movementVector * Time.deltaTime);
        BroadcastSpeed?.Invoke(movementVector.magnitude);
    }
}
