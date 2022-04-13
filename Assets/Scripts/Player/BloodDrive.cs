using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDrive : MonoBehaviour
{
    private const float DRIVE_MAX_VALUE = 100f;

    public float DriveValue { get; private set; }

    public float GetDriveFillPercent()
    {
        return DriveValue / DRIVE_MAX_VALUE;
    }

}
