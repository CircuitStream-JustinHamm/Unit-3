using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRigidbodyMovement : PlayerMovementBehaviour
{
    [SerializeField]
    private ForceMode forceMode = ForceMode.VelocityChange;

    new private Rigidbody rigidbody;

    void Start()
    { rigidbody = GetComponent<Rigidbody>(); }

    protected override void Update()
    {
        base.Update();
        BroadcastSpeed?.Invoke(rigidbody.linearVelocity.magnitude);
    }

    protected override void ApplyMovement(Vector3 movementVector)
    { rigidbody.AddForce(movementVector * Time.deltaTime, forceMode); }
}
