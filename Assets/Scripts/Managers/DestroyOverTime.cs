using System;
using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float Time;

    private void Start()
    {
        StartCoroutine(nameof(WaitAndDestroy));
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(Time);
        Destroy(gameObject);
    }
}
