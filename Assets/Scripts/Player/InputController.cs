using System;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private GameObject Player;
    private PlayerWeapons Weapons;

    [SerializeField] private Button ButtonAttack;
    [SerializeField] private Button ButtonWeaponChange;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Weapons = Player.GetComponent<PlayerWeapons>();
        AddListenerToButtons();
    }

    private void AddListenerToButtons()
    {
        if (ButtonAttack != null)
            ButtonAttack.onClick.AddListener(Attack);
        if (ButtonWeaponChange != null)
            ButtonWeaponChange.onClick.AddListener(ChangeWeapon);
    }

    public void Attack() => Weapons.DoAttack();

    public void ChangeWeapon()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
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
        }*/
        Weapons.NextWeapon();

    }
}