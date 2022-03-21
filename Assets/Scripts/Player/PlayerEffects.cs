using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private GameObject GotDamageParticle;

    private Animator animator;


    private void Start()
    {
        PlayerHealth health = GetComponent<PlayerHealth>();
        health.OnHealthChanged += GotDamageEffects;
        animator = GetComponentInChildren<Animator>();
    }

    private void GotDamageEffects()
    {
        Instantiate(GotDamageParticle, transform);
        animator.SetTrigger("GotDamage");
    }

    private void DeathEffects()
    {

    }
}
