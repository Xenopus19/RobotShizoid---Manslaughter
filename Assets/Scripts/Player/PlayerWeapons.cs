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
        
    }
    public void AddWeapon(GameObject newWeapon)
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

    public void ChangeWeapon(int NewWeaponIndex)
    {
        if(CurrentWeapon!=null)
            Destroy(CurrentWeapon.gameObject);
        
        if(AviableWeapons[NewWeaponIndex]!=null)
            CurrentWeapon = Instantiate(AviableWeapons[NewWeaponIndex], AttackOrigin).GetComponent<Weapon>();
    }

    public void DoAttack()
    { 
        if(CurrentWeapon!=null)
        CurrentWeapon.Attack(AttackOrigin.position);
    }
}
