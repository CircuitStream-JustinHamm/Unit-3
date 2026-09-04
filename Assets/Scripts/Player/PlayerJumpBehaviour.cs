using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerJumpBehaviour : MonoBehaviour
{
    public UnityEvent OnJump;

    [SerializeField] protected float force;

    private bool isGrounded;
    private bool jumpInput;

    private void Update()
    {
        ApplyJump();

        if (ShouldJump())
        { 
            Jump(); 
            OnJump?.Invoke();
        }
    }

    protected virtual void ApplyJump()
    { }

    protected abstract void Jump();

    private bool ShouldJump()
    { return jumpInput && isGrounded; }

    public void SetGrounded(bool value)
    { isGrounded = value; }

    public void SetJumpInput(bool value)
    { jumpInput = value; }
}
