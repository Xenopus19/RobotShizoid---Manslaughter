using UnityEngine;

public class PlaySoundTutorial : MonoBehaviour {
    [SerializeField] private AudioSource SoundPlayer;
    public void PlayCompleteSound() => SoundPlayer.Play();
}