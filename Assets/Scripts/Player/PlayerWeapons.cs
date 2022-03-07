using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] Transform AttackOrigin;

    [SerializeField] private GameObject Stick;
    [SerializeField] private GameObject Pencil;
    [SerializeField]private GameObject[] AviableWeapons;
    private Weapon CurrentWeapon;

    private void Start()
    {
        AddWeapon(Stick);
        AddWeapon(Pencil);
        ChangeWeapon(0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            DoAttack();
        }
        CheckChangeWeaponKey();
    }

    private void CheckChangeWeaponKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeWeapon(4);
        }
    }
    private void AddWeapon(GameObject newWeapon)
    {
        for(int i = 0; i<AviableWeapons.Length; i++)
        {
            if (AviableWeapons[i] == null)
            {
                AviableWeapons[i] = newWeapon;
                return;
            } 
        }

        AviableWeapons[AviableWeapons.Length - 1] = newWeapon;
    }

    private void ChangeWeapon(int NewWeaponIndex)
    {
        if(CurrentWeapon!=null)
            Destroy(CurrentWeapon.gameObject);
        
        if(AviableWeapons[NewWeaponIndex]!=null)
            CurrentWeapon = Instantiate(AviableWeapons[NewWeaponIndex], AttackOrigin).GetComponent<Weapon>();
    }

    private void DoAttack()
    { 
        CurrentWeapon?.Attack(AttackOrigin.position);
    }
}
