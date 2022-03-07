using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private GameObject LiveIcon;

    private void Start()
    {
        playerHealth.OnLivesChange += UpdateLivesPanel;
    }
    private void UpdateLivesPanel()
    {
        Debug.Log("Sa sasla sa sa sa sa sasla");
        if (playerHealth.LivesAmount < transform.childCount)
        {
            DestroyLiveIcon();
        }
        else
        {
            CreateLiveIcon();
        }
    }
    public void DestroyLiveIcon()
    {
        if (transform.childCount == 0) return;
        Transform childToDestroy = transform.GetChild(transform.childCount - 1);
        if(childToDestroy!=null)
        {
            Destroy(childToDestroy.gameObject);
        }
    }
    public void CreateLiveIcon()
    {
        Instantiate(LiveIcon, transform);
    }
}
