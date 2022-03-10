using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour {
    private string MusicExposedParam = "Music";
    private string EffectsExposedParam = "Effects";

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource audioSourceBGM;

    [SerializeField] private int VolumeMultiplier;

    private void Awake() {
        if (PlayerPrefs.HasKey("MusicVolume"))
            SetGroupVolume(MusicExposedParam, PlayerPrefs.GetFloat("MusicVolume"));

        if (PlayerPrefs.HasKey("EffectsVolume"))
            SetGroupVolume(EffectsExposedParam, PlayerPrefs.GetFloat("EffectsVolume"));
    }

    private void Start() {
        if (audioSourceBGM != null)
            audioSourceBGM.Play();
    }

    public void SetGroupVolume(string ExposedParam, float newVolume) {
        audioMixer.SetFloat(ExposedParam, LerpSliderValue(newVolume));
    }

    public void ChangeMusicVolume(Slider slider) {
        SetGroupVolume(MusicExposedParam, slider.value);
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
    }

    public void ChangeEffectVolume(Slider slider) {
        SetGroupVolume(EffectsExposedParam, slider.value);
        PlayerPrefs.SetFloat("EffectsVolume", slider.value);
    }

    private float LerpSliderValue(float value) {
        if (value == 0) {
            return -80;
        } else {
            return 20f * Mathf.Log10(value);
        }
    }
}