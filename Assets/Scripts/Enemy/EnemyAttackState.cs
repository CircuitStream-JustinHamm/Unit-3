using UnityEngine;

public class EnemyAttackState : EnemyState
{
    float _distanceToPlayer;

    public EnemyAttackState(Enemy enemy) : base(enemy)
    { }

    public override void OnStateEnter()
    { }

    public override void OnStateExit()
    { }

    public override void OnStateUpdate()
    {
        if (_enemy.player != null)
            _distanceToPlayer = Vector3.Distance(_enemy.transform.position, _enemy.player.position);

        if (ShouldTransitionToFollow())
            TransitionToFollow();

        else
            Attack();
    }

    private void Attack()
    {
        Health playerHealth = _enemy.player.GetComponent<Health>();
        if (playerHealth != null)
            playerHealth.AdjustHealth(-10 * Time.deltaTime);
    }

    private bool ShouldTransitionToFollow()
    { return _enemy.player == null || _distanceToPlayer >= 2; }

    private void TransitionToFollow()
    { _enemy.ChangeState(new EnemyFollowState(_enemy)); }
}
