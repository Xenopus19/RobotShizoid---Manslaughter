using UnityEngine;

public class WeaponEffects : MonoBehaviour
{
    [SerializeField] string AnimationName;
    [SerializeField] AudioClip[] StrikeSoundVariations;
    [SerializeField] GameObject SlashPrefab;

    private Animator animator;
    private AudioSource audioSourse;
    private void Start()
    {
        audioSourse = GetComponent<AudioSource>();
        animator = GetComponentInParent<Animator>();
        Weapon weapon = GetComponent<Weapon>();

        weapon.OnAttack += CreateEffects;
    }
    private void CreateEffects()
    {
        PlayAnimation();
    }

    public void CreateDelayedEffects(Vector3 AttackPos)
    {
        PlaySlash(AttackPos);
        PlaySound();
    }

    private void PlayAnimation()
    {
        animator.SetTrigger(AnimationName);
    }

    private void PlaySlash(Vector3 AttackPos)
    {
        if (SlashPrefab != null) Instantiate(SlashPrefab, AttackPos, Quaternion.identity);
    }

    private void PlaySound()
    {
        audioSourse.clip = StrikeSoundVariations[Random.Range(0, StrikeSoundVariations.Length - 1)];
        audioSourse.Play();
    }
}
