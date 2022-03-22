using System.Collections;
using System;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public Action OnWeaponChanged;

    [SerializeField] Transform AttackOrigin;

    [SerializeField] private GameObject Stick;
    [SerializeField] private GameObject Pencil;
    [SerializeField]private GameObject[] AviableWeapons;
    private Weapon CurrentWeapon;

    public Weapon GetCurrentWeapon()
    {
        return CurrentWeapon;
    }
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
        if (AviableWeapons[NewWeaponIndex] != null)
        {
            if (CurrentWeapon != null)
                Destroy(CurrentWeapon.gameObject);

            CurrentWeapon = Instantiate(AviableWeapons[NewWeaponIndex], AttackOrigin).GetComponent<Weapon>();

            if (OnWeaponChanged != null)
                OnWeaponChanged.Invoke();
        }
    }

    public void DoAttack()
    { 
        if(CurrentWeapon!=null)
        CurrentWeapon.Attack(AttackOrigin.position);
    }
}
