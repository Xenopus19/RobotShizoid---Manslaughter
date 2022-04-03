using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneSkip : MonoBehaviour
{
    [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private VideoPlayer player;
    private float CutsceneLength;

    private void Start()
    {
        CutsceneLength = (float)player.clip.length;
        StartCoroutine(nameof(SkipOnClipEnd));
    }

    private IEnumerator SkipOnClipEnd()
    {
        yield return new WaitForSeconds(CutsceneLength);
        SkipCutscene();
    }

    public void SkipCutscene()
    {
        MenuCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
