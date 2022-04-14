using UnityEngine;
using UnityEngine.UI;

public class BloodDriveUI : MonoBehaviour {
    private GameObject Player;
    private Image BloodDriveScale;
    private BloodDrive bloodDrive;

    void Start() {
        BloodDriveScale = GetComponent<Image>();

        Player = GameObject.FindGameObjectWithTag("Player");
        bloodDrive = Player.GetComponent<BloodDrive>();
        bloodDrive.OnDriveValueChange += UpdateUI;
        UpdateUI();
    }

    public void UpdateUI() {
        BloodDriveScale.fillAmount = bloodDrive.GetDriveFillPercent();
    }
}
