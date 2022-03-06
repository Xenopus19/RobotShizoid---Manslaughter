using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private Image HealthBarImage;
    [SerializeField] private Animator BarAnim;

    [SerializeField] private float LowHealthPercent;

    private void Start()
    {
        playerHealth.OnHealthChanged += UpdateHealthBar;
    }
    

    private void UpdateHealthBar()
    {
        float HealthPercent = playerHealth.HealthAmount / playerHealth.MaxHealth;
        HealthBarImage.fillAmount = HealthPercent;

        ManageLowHpAnimation(HealthPercent);
    }

    private void ManageLowHpAnimation(float HealthPercent)
    {
        if (HealthPercent <= LowHealthPercent)
        {
            BarAnim.SetBool("IsLowHp", true);
        }
        else
        {
            BarAnim.SetBool("IsLowHp", false);
        }
    }
}
