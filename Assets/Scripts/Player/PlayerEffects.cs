using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private GameObject GotDamageParticle;

    private Animator animator;
    private PlayerWeapons weapons;
    private Image WeaponIcon;


    private void Start()
    {
        PlayerHealth health = GetComponent<PlayerHealth>();
        health.OnHealthChanged += GotDamageEffects;
        animator = GetComponentInChildren<Animator>();
        weapons = GetComponent<PlayerWeapons>();
        WeaponIcon = GameObject.FindGameObjectWithTag("WeaponIcon").GetComponent<Image>();
        weapons.OnWeaponChanged += UpdateWeaponIcons;
        UpdateWeaponIcons();
    }

    private void GotDamageEffects()
    {
        Instantiate(GotDamageParticle, transform);
        animator.SetTrigger("GotDamage");
    }

    private void UpdateWeaponIcons()
    {
        Sprite CurrentWeaponIcon = weapons.GetCurrentWeapon().Icon;
        if (CurrentWeaponIcon != null)
        {
            WeaponIcon.sprite = CurrentWeaponIcon;
        }
        else
        {
            WeaponIcon.sprite = null;
        }
    }
}
