using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] MeshRenderer doorRenderer;

    [SerializeField] Color closedColor;
    [SerializeField] Color openColor;
    [SerializeField] Color delayColor;

    [SerializeField] float openDelay = 1.0f;
    float openTimer = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            openTimer = 0;
            doorRenderer.material.color = delayColor;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
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

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", false);
            doorRenderer.material.color = closedColor;
        }
    }
}
