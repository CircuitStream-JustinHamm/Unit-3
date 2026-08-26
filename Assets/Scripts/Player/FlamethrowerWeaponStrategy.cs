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

    private void OnParticleCollision(GameObject other)
    {
        // Do something to target game object
        Debug.Log(other.name);
    }
}