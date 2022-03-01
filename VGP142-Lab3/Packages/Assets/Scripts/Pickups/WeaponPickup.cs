using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    public enum Weapon
    {
        GREYGREATSWORD,
        BLUEGREATSWORD
    }

    [SerializeField] Weapon weapon;

    public override void OnPickup(Collider other)
    {
        switch (weapon)
        {
            case Weapon.BLUEGREATSWORD:
                other.GetComponent<PlayerController>().EquipBlueGreatsword();
                break;
            case Weapon.GREYGREATSWORD:
                other.GetComponent<PlayerController>().EquipGreyGreatsword();
                break;
        }

        //Destroy(gameObject);
    }
}
