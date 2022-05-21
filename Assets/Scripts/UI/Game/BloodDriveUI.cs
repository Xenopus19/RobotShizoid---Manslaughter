using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodDriveUI : MonoBehaviour {
    [SerializeField] private GameObject driveEffects;
    [SerializeField] private List<GameObject> BGMG = new List<GameObject>();

    private GameObject Player;
    private Image BloodDriveScale;
    private BloodDrive bloodDrive;
    private AudioSource audioSource;
    

    void Start() {
        BloodDriveScale = GetComponent<Image>();

        Player = GameObject.FindGameObjectWithTag("Player");
        bloodDrive = Player.GetComponent<BloodDrive>();
        bloodDrive.OnDriveValueChange += UpdateUI;
        bloodDrive.OnBloodDrive += BeginDriveEffects;
        audioSource = GetComponent<AudioSource>();
        UpdateUI();
    }

    public void UpdateUI() {
        BloodDriveScale.fillAmount = bloodDrive.GetDriveFillPercent();
    }

    private void BeginDriveEffects(float DriveTime)
    {
        AudioSource BGM = DefineBGM();
        driveEffects.SetActive(true);
        BGM.pitch = 0.5f;
        BGM.spatialBlend = 0.5f;

        StartCoroutine(FinishEffects(DriveTime, BGM));
    }

    private AudioSource DefineBGM()
    {
        for (int i = 0; i < BGMG.Count; i++)
        {
            if (BGMG[i].activeInHierarchy)
                return BGMG[i].GetComponent<AudioSource>();
        }
        return null;
    }

    private IEnumerator FinishEffects(float DriveTime, AudioSource BGM)
    {
        yield return new WaitForSeconds(DriveTime);
        BGM.pitch = 1;
        BGM.spatialBlend = 0;
        audioSource.Play();
        driveEffects.SetActive(false);
    }
}
