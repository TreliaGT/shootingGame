using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [Header("Ammo")]
    public int Ammo = 10;

    public void pickup(out int ammoToAdd)
    {
        ammoToAdd = 5;
        Destroy(gameObject);
    }
}
