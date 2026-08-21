using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy) : base(enemy)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Entered Attack State!");
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {

    }
}
