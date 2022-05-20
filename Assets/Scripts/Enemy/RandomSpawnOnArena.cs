using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnOnArena : MonoBehaviour
{
    public Vector3 MinPosition;
    public Vector3 MaxPosition;

    private void Start()
    {
        Vector3 NewPos = new Vector3();
        NewPos.y = Random.Range(MinPosition.y, MaxPosition.y);
        NewPos.x = Random.Range(MinPosition.x, MaxPosition.x);
        NewPos.z = Random.Range(MinPosition.z, MaxPosition.z);

        transform.position = NewPos;
    }
}
