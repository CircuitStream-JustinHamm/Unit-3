using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private EnemyState _currentState;

    public Transform[] patrolPoints;

    public Transform enemyEye;
    public float sightRadius;
    public float sightDistance;

    public NavMeshAgent agent;

    [HideInInspector] public Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _currentState = new EnemyPatrolState(this);
        _currentState.OnStateEnter();
    }

    void Update()
    { _currentState.OnStateUpdate(); }

    public void ChangeState(EnemyState state)
    {
        _currentState.OnStateExit();
        _currentState = state;
        _currentState.OnStateEnter();
    }
}
