using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private PlayerMovement Movement;
    private PlayerWeapons Weapons;
    private void Start()
    {
        Movement = GetComponent<PlayerMovement>();
        Weapons = GetComponent<PlayerWeapons>();
    }
    private void Update()
    {
        CheckWeaponChangeInput();
        CheckAttackKey();
    }

    private void CheckAttackKey()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Weapons.DoAttack();
        }
    }

    private void CheckWeaponChangeInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Weapons.ChangeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Weapons.ChangeWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Weapons.ChangeWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Weapons.ChangeWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Weapons.ChangeWeapon(4);
        }
    }
}
