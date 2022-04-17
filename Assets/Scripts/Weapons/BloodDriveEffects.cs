using UnityEngine;
using System.Collections;
using System;

public class BloodDriveEffects : MonoBehaviour
{
    [SerializeField] float DriveEffectsCoefficient;
    [SerializeField] GameObject VisualEffects;
    private SphereMelee sphereMelee;
    private BloodDrive bloodDrive;

    void Start()
    {
        sphereMelee = GetComponent<SphereMelee>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        bloodDrive = Player.GetComponent<BloodDrive>();
        bloodDrive.OnBloodDrive += MakeBloodDriveEffets;
    }

    private void MakeBloodDriveEffets(float DriveTime)
    {
        EnhanceWeapon(DriveTime);
        ChangeEffectsActivity();
    }

    private void EnhanceWeapon(float DriveTime)
    {
        ChangeValues(DriveEffectsCoefficient);
        StartCoroutine(WaitDrive(DriveTime));
    }

    private void WeakenWeapon()
    {
        ChangeValues(1 / DriveEffectsCoefficient);
    }

    private void ChangeValues(float EffectsCoefficient)
    {
        sphereMelee.Cooldown *= 1 / EffectsCoefficient;
        sphereMelee.Damage *= EffectsCoefficient;
        sphereMelee.AttackRadius *= EffectsCoefficient;
    }

    private void ChangeEffectsActivity()
    {
        VisualEffects.SetActive(!VisualEffects.activeInHierarchy);
    }

    private IEnumerator WaitDrive(float DriveTime)
    {
        yield return new WaitForSeconds(DriveTime);
        WeakenWeapon();
        ChangeEffectsActivity();
    }

    private void OnDestroy()
    {
        bloodDrive.OnBloodDrive -= MakeBloodDriveEffets;
    }
}
