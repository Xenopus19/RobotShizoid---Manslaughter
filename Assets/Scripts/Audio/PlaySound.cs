using UnityEngine;

public class PlaySound : MonoBehaviour {
    [SerializeField] private AudioSource SoundPlayer;
    public void PlayCompleteSound() => SoundPlayer.Play();
}