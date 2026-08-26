using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private WeaponStrategy[] weapons;
    [SerializeField] public Transform shootPoint;
    [SerializeField] public Transform cameraPivot;

    private int currentWeapon;

    private bool shootInput;
    private bool nextWeaponInput;
    private bool previousWeaponInput;

    private void Start()
    { currentWeapon = 0; }

    private void Update()
    {
        if(nextWeaponInput)
        { NextWeapon(); }
        else if (previousWeaponInput)
        { PreviousWeapon(); }

        if (shootInput)
        { Shoot(); }
    }

    private void NextWeapon()
    {
        weapons[currentWeapon].OnUnequip(this);
        currentWeapon = (currentWeapon + 1) % weapons.Length;
        weapons[currentWeapon].OnEquip(this);
    }

    private void PreviousWeapon()
    {
        weapons[currentWeapon].OnUnequip(this);
        currentWeapon -= 1;
        if (currentWeapon < 0)
            currentWeapon = weapons.Length - 1;
        weapons[currentWeapon].OnEquip(this);
    }

    private void Shoot()
    { weapons[currentWeapon].Shoot(this); }

    public void SetShootInput(bool value)
    { shootInput = value; }

    public void SetNextWeaponInput(bool value)
    { nextWeaponInput = value; }

    public void SetPreviousWeaponInput(bool value)
    { previousWeaponInput = value; }
}