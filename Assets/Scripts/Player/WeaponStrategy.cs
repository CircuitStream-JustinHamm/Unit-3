using UnityEngine;

public abstract class WeaponStrategy : MonoBehaviour
{
    public abstract void Shoot(ShootBehaviour shootBehaviour);

    public virtual void OnEquip(ShootBehaviour shootBehaviour)
    { }
    public virtual void OnUnequip(ShootBehaviour shootBehaviour)
    { }
}