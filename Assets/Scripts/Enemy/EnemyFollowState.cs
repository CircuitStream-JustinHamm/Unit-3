using UnityEngine;

public class EnemyFollowState : EnemyState
{
    float _distanceToPlayer;

    public EnemyFollowState(Enemy enemy) : base(enemy)
    { }

    public override void OnStateEnter()
    { }

    public override void OnStateExit()
    { }

    public override void OnStateUpdate()
    {
        if (_enemy.player != null)
            _distanceToPlayer = Vector3.Distance(_enemy.transform.position, _enemy.player.position);

        if (ShouldTransitionToPatrol())
            TransitionToPatrol();

        else if (ShouldTransitionToAttack())
            TransitionToAttack();

        else
            Follow();
    }

    private void Follow()
    { _enemy.agent.SetDestination(_enemy.player.position); }

    private bool ShouldTransitionToPatrol()
    { return _enemy.player == null || _distanceToPlayer > 10; }

    private bool ShouldTransitionToAttack()
    { return _distanceToPlayer <= 2; }

    private void TransitionToPatrol()
    { _enemy.ChangeState(new EnemyPatrolState(_enemy)); }

    private void TransitionToAttack()
    { _enemy.ChangeState(new EnemyAttackState(_enemy)); }
}
