using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public List<WeaponController> startingWeapons = new List<WeaponController>();
    public Transform weaponParentSocket;
    public Transform aimingPosition;
    public Transform defaultWeaponPosition;

    public int activeWeaponIndex { get; private set; }

    private WeaponController[] weaponSlots = new WeaponController[5];

    void Start()
    {
        activeWeaponIndex = -1;
    }

    void Update()
    {
        // Add your update logic here if needed
    }

    private void AddWeapon(WeaponController p_weaponPrefab)
    {
        weaponParentSocket.position = defaultWeaponPosition.position;
        // Add more logic for adding the weapon if needed
    }
}
