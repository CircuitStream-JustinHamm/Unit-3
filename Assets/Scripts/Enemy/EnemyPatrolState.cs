using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    int currentTarget = 0;

    public EnemyPatrolState(Enemy enemy) : base(enemy)
    { }

    public override void OnStateEnter()
    { _enemy.agent.SetDestination(GetTargetPosition()); }

    public override void OnStateExit()
    { }

    public override void OnStateUpdate()
    {
        Patrol();

        if(ShouldTransitionToFollow())
            TransitionToFollow();
    }

    private void Patrol()
    {
        if (_enemy.agent.remainingDistance < 0.1f)
        {
            // We've hit our target!

            /*currentTarget++;
            if (currentTarget >= _enemy.patrolPoints.Length)
                currentTarget = 0;*/

            currentTarget = GetNextTarget();
            _enemy.agent.SetDestination(GetTargetPosition());
        }
    }

    private bool ShouldTransitionToFollow()
    {
        if(Physics.SphereCast(_enemy.enemyEye.position, _enemy.sightRadius, _enemy.transform.forward, out RaycastHit info, _enemy.sightDistance))
        {
            if(info.transform.CompareTag("Player"))
            {
                _enemy.player = info.transform;
                return true;
            }
        }
        return false;
    }

    private void TransitionToFollow()
    {
        _enemy.agent.SetDestination(_enemy.player.position);
        _enemy.ChangeState(new EnemyFollowState(_enemy));
    }

    private Vector3 GetTargetPosition()
    { return _enemy.patrolPoints[currentTarget].position; }

    private int GetNextTarget()
    { return (currentTarget + 1) % _enemy.patrolPoints.Length; }
}
