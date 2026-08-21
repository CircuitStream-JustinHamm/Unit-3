public abstract class EnemyState
{
    protected Enemy _enemy;

    public EnemyState(Enemy enemy)
    { _enemy = enemy; }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();
}
