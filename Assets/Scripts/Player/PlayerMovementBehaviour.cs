using UnityEngine;

public abstract class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private float horizontalInput;
    private float verticalInput;

    protected abstract void ApplyMovement(Vector3 movementVector);

    void Update()
    { Move(); }

    private void Move()
    {
        Vector3 movementVector = Vector3.ClampMagnitude(new Vector3(horizontalInput, 0, verticalInput), 1);
        movementVector = transform.rotation * movementVector;

        movementVector *= movementSpeed;

        ApplyMovement(movementVector);
    }

    public void SetHorizontalInput(float value)
    { horizontalInput = value; }

    public void SetVerticalInput(float value)
    { verticalInput = value; }
}
