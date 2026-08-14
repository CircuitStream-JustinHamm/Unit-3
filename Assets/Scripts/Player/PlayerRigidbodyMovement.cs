using UnityEngine;

public class PlayerRigidbodyMovement : PlayerMovementBehaviour
{
    [SerializeField]
    private ForceMode forceMode = ForceMode.VelocityChange;

    new private Rigidbody rigidbody;

    void Start()
    { rigidbody = GetComponent<Rigidbody>(); }

    protected override void ApplyMovement(Vector3 movementVector)
    { rigidbody.AddForce(movementVector * Time.deltaTime, forceMode); }
}
