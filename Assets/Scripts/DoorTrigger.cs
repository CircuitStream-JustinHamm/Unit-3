using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("Open", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", false);
        }
    }
}
