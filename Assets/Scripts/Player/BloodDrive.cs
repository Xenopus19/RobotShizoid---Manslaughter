using System;
using System.Collections;
using UnityEngine;

public class BloodDrive : MonoBehaviour {
    public float DriveValue { get; private set; }
    private const float DRIVE_MAX_VALUE = 100f;

    [SerializeField] float BloodDriveTime;

    public Action OnDriveValueChange;
    public Action<float> OnBloodDrive;

    [HideInInspector] public bool IsBloodDrive = false;
    private void Start() => IsBloodDrive = false;

    public float GetDriveFillPercent() {
        return DriveValue / DRIVE_MAX_VALUE;
    }

    public void IncreaseDriveValue(float toAdd) {
        if (!IsBloodDrive) {
            DriveValue += toAdd;
            OnDriveValueChange?.Invoke();
            if (DriveValue >= DRIVE_MAX_VALUE) {
                OnBloodDrive?.Invoke(BloodDriveTime);
                StartCoroutine(nameof(BloodDriveProcess));
            }
        }
    }

    private void DecreaseDriveValue() {
        DriveValue = 0;
        OnDriveValueChange?.Invoke();
        IsBloodDrive = false;
    }

    private IEnumerator BloodDriveProcess() {
        IsBloodDrive = true;
        //Effects
        yield return new WaitForSeconds(BloodDriveTime);
        DecreaseDriveValue();
    }
}