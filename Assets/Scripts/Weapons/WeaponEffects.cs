using UnityEngine;

public class WeaponEffects : MonoBehaviour
{
    [SerializeField] string AnimationName;
    [SerializeField] AudioClip[] StrikeSoundVariations;

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
        //PlaySound();
    }

    private void PlayAnimation()
    {
        animator.SetTrigger(AnimationName);
    }
    private void PlaySound()
    {
        audioSourse.clip = StrikeSoundVariations[Random.Range(0, StrikeSoundVariations.Length - 1)];
        audioSourse.Play();
    }
}
