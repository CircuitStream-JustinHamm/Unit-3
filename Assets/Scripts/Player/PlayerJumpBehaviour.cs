using UnityEngine;

public abstract class PlayerJumpBehaviour : MonoBehaviour
{
    [SerializeField] protected float force;

    private bool isGrounded;
    private bool jumpInput;

    private void Update()
    {
        ApplyJump();

        if (ShouldJump())
        { Jump(); }
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
