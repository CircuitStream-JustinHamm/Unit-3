using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private ObjectPool projectilePool;
    [SerializeField] private float projectileVelocity;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform cameraPivot;

    [SerializeField] private float lifetime;

    new private Rigidbody rigidbody;
    private bool shootInput;

    private void Start()
    { rigidbody = GetComponent<Rigidbody>(); }

    private void Update()
    {
        if(shootInput)
        { Shoot(); }
    }

    private void Shoot()
    {
        PooledObject projectile = projectilePool.GetPooledObject();
        if (projectile == null)
            return;

        projectile.gameObject.SetActive(true);

        Rigidbody projectileBody = projectile.GetComponent<Rigidbody>();

        projectile.transform.position = shootPoint.position;
        projectile.transform.rotation = cameraPivot.rotation;

        Vector3 force = projectile.transform.forward * projectileVelocity;

        if(rigidbody != null)
        {
            force += rigidbody.linearVelocity;
        }

        projectileBody.AddForce(force, ForceMode.Impulse);
        projectilePool.RecyclePooledObject(projectile, lifetime);
    }

    public void SetShootInput(bool value)
    { shootInput = value; }
}