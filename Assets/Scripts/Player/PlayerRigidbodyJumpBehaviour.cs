using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRigidbodyJumpBehaviour : PlayerJumpBehaviour
{
    [SerializeField] private ForceMode forceMode = ForceMode.Impulse;
    new private Rigidbody rigidbody;

    private void Start()
    { rigidbody = GetComponent<Rigidbody>(); }

    protected override void Jump()
    {
        Debug.Log("Pressed Jump!");
        rigidbody.AddForce(Vector3.up * force, forceMode); 
    }
}
