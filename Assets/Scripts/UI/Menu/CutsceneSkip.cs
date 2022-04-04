using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneSkip : MonoBehaviour
{
    [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private VideoPlayer player;
    [SerializeField] private GameObject postProcessing;

    private static bool CutsceneWasShown = false;
    private float CutsceneLength;

    private void Start()
    {
        if (CutsceneWasShown)
        {
            SkipCutscene();
        }
        else
        {
            CutsceneLength = (float)player.clip.length;
            StartCoroutine(nameof(SkipOnClipEnd));
        }
    }

    private IEnumerator SkipOnClipEnd()
    {
        yield return new WaitForSeconds(CutsceneLength);
        SkipCutscene();
    }

    public void SkipCutscene()
    {
        CutsceneWasShown = true;
        MenuCanvas.SetActive(true);
        postProcessing.SetActive(true);
        gameObject.SetActive(false);
    }
}
