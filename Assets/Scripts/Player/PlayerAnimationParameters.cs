using UnityEngine;

public class PlayerAnimationParameters : MonoBehaviour
{
    public Animator animator;
    private float speed;
    private bool grounded;
    private bool jump;

    private void Update()
    {
        animator.SetFloat("Speed", speed);
        animator.SetBool("FreeFall", !grounded);
        animator.SetBool("Grounded", grounded);
        animator.SetBool("Jump", jump);

        jump = false;
    }

    public void SetSpeed(float value)
    { speed = value; }

    public void SetGrounded(bool value)
    { grounded = value; }

    public void SetJump(bool value)
    { jump = value; }
}
