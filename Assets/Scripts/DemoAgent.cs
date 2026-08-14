using UnityEngine;
using UnityEngine.AI;

public class DemoAgent : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    [SerializeField] NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetDestination.position);
    }
}
