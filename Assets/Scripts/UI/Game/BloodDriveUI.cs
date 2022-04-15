using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BloodDriveUI : MonoBehaviour {
    [SerializeField] private GameObject driveEffects;
    [SerializeField] private AudioSource BGM;

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
        driveEffects.SetActive(true);
        BGM.pitch = 0.5f;
        BGM.spatialBlend = 0.5f;

        StartCoroutine(FinishEffects(DriveTime));
    }

    private IEnumerator FinishEffects(float DriveTime)
    {
        yield return new WaitForSeconds(DriveTime);
        BGM.pitch = 1;
        BGM.spatialBlend = 0;
        audioSource.Play();
        driveEffects.SetActive(false);
    }
}
