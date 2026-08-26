using UnityEngine;

public class ParticleWeaponStrategy : WeaponStrategy
{
    [SerializeField] ParticleSystem particles;

    public override void Shoot(ShootBehaviour shootBehaviour)
    {
        if(particles.isPlaying)
        {
            particles.Stop();
        }
        else
        {
            particles.Play();
        }
    }

    public override void OnUnequip(ShootBehaviour shootBehaviour)
    {
        particles.Stop();
    }
}