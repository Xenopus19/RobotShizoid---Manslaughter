using System;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {
    private GameObject Player;
    private PlayerWeapons Weapons;

    [SerializeField] private Button ButtonAttack;
    [SerializeField] private Button ButtonWeaponChange;
    private void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        Weapons = Player.GetComponent<PlayerWeapons>();
        AddListenerToButtons();
    }

    private void AddListenerToButtons() {
        if (ButtonAttack != null)
            ButtonAttack.onClick.AddListener(Attack);
        if (ButtonWeaponChange != null)
            ButtonWeaponChange.onClick.AddListener(ChangeWeapon);
    }

    public void Attack() => Weapons.DoAttack();

    public void ChangeWeapon() {
        print("change");
        Weapons.NextWeapon();
    }
}