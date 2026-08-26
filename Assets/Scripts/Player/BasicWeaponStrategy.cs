using UnityEngine;

public abstract class EntityMovementStrategy
{ public abstract void Move(Rigidbody rigidbody); }

public class BasicMovementStrategy : EntityMovementStrategy
{
    public float velocity;

    public override void Move(Rigidbody rigidbody)
    {
        Vector3 force = rigidbody.transform.forward * velocity;
        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    public BasicMovementStrategy(float targetVelocity)
    { velocity = targetVelocity; }
}

public class MomentumMovementStrategy : EntityMovementStrategy
{
    public Rigidbody ownerRigidbody;
    public float velocity;

    public override void Move(Rigidbody rigidbody)
    {
        Vector3 force = rigidbody.transform.forward * velocity;

        if (ownerRigidbody != null)
        {
            force += ownerRigidbody.linearVelocity;
        }

        rigidbody.AddForce(force, ForceMode.Impulse);
    }
}

public class DropMovementStrategy : EntityMovementStrategy
{
    public float velocity;

    public override void Move(Rigidbody rigidbody)
    {
        Vector3 force = Physics.gravity.normalized * velocity;
        rigidbody.AddForce(force, ForceMode.Impulse);
    }
}

public class RiseMovementStrategy : EntityMovementStrategy
{
    public float velocity;

    public override void Move(Rigidbody rigidbody)
    {
        Vector3 force = -Physics.gravity.normalized * velocity;
        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    public RiseMovementStrategy(float targetVelocity)
    { velocity = targetVelocity; }
}

public class BasicWeaponStrategy : WeaponStrategy
{
    EntityMovementStrategy movementStrategy;
    [SerializeField] private ObjectPool projectilePool;
    [SerializeField] private float projectileVelocity;
    [SerializeField] private float lifetime;

    private void Start()
    { movementStrategy = new BasicMovementStrategy(projectileVelocity); }

    public override void Shoot(ShootBehaviour shootBehaviour)
    {
        PooledObject projectile = projectilePool.GetPooledObject();
        if (projectile == null)
            return;

        projectile.gameObject.SetActive(true);

        Rigidbody projectileBody = projectile.GetComponent<Rigidbody>();

        projectile.transform.position = shootBehaviour.shootPoint.position;
        projectile.transform.rotation = shootBehaviour.cameraPivot.rotation;

        movementStrategy.Move(projectileBody);

        projectilePool.RecyclePooledObject(projectile, lifetime);
    }
}