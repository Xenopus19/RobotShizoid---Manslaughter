using UnityEngine.UI;
using UnityEngine;

public class BloodDriveIcon : MonoBehaviour
{
    private Image driveIcon;

    private BloodDrive bloodDrive;
    private void Start()
    {
        bloodDrive = GameObject.FindGameObjectWithTag("Player").GetComponent<BloodDrive>();
        driveIcon = GetComponent<Image>();
    }

    private void Update()
    {
        driveIcon.fillAmount = bloodDrive.GetDriveFillPercent();
        
    }
}
