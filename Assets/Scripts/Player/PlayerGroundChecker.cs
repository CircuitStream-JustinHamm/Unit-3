using UnityEngine;
using UnityEngine.Events;

public class PlayerGroundChecker : MonoBehaviour
{
    public Transform groundCheckTransform;
    public UnityEvent<bool> BroadcastGrounded;
    public float groundDistance = 0.6f;

    // Update is called once per frame
    void Update()
    {
        bool grounded = false;
        Ray ray = new Ray(groundCheckTransform.position, Vector3.down);
        grounded = Physics.Raycast(ray, groundDistance);

        BroadcastGrounded?.Invoke(grounded);
    }
}
