using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] string targetTag = "Player";

    [SerializeField] Animator animator;
    [SerializeField] MeshRenderer doorRenderer;

    [SerializeField] Color closedColor;
    [SerializeField] Color openColor;
    [SerializeField] Color delayColor;

    [SerializeField] float openDelay = 1.0f;
    [SerializeField] bool doorEnabled = false;

    float openTimer = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (doorEnabled)
        {
            if (other.tag == targetTag)
            {
                openTimer = 0;
                doorRenderer.material.color = delayColor;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (doorEnabled)
        {
            if (other.tag == targetTag)
            {
                if (openTimer < openDelay)
                {
                    openTimer += Time.deltaTime;
                }
                else
                {
                    animator.SetBool("Open", true);
                    doorRenderer.material.color = openColor;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (doorEnabled)
        {
            if (other.tag == targetTag)
            {
                animator.SetBool("Open", false);
                doorRenderer.material.color = closedColor;
            }
        }
    }

    public void SetDoorEnabled(bool shouldEnable)
    {
        doorEnabled = shouldEnable;
    }
}
