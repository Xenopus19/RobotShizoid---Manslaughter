using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class ResolurionSettings : MonoBehaviour {

    [Header("Settings Objects")]
    [SerializeField] private Dropdown ResolutionDropdown;
    [SerializeField] private Toggle FullscreenToggleObject;

    private Resolution[] resolutions;
    private bool LastFullScreenSettings;
    private void Start() {
        LastFullScreenSettings = Screen.fullScreen;
        FullscreenToggleObject.isOn = Screen.fullScreen;
        AddResolutionOptions(); 
    }

    private void Update() {
        if (LastFullScreenSettings != Screen.fullScreen) {
            FullscreenToggleObject.isOn = Screen.fullScreen;
            LastFullScreenSettings = Screen.fullScreen;
        }
    }

    private void AddResolutionOptions() {
        Resolution[] res = Screen.resolutions;
        resolutions = res.Distinct().ToArray();

        string[] stringResolutions = new string[resolutions.Length];

        for (int i = 0; i < stringResolutions.Length; i++) {
            stringResolutions[i] = resolutions[i].ToString();
            stringResolutions[i] = stringResolutions[i].Remove(stringResolutions[i].Length - 7);
        }

        ResolutionDropdown.ClearOptions();
        ResolutionDropdown.AddOptions(stringResolutions.ToList());

        if (PlayerPrefs.HasKey("Resolution")) {
            ResolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
        }
    }

    public void SetResolution() {
        Screen.SetResolution(resolutions[ResolutionDropdown.value].width, resolutions[ResolutionDropdown.value].height, true);
        PlayerPrefs.SetInt("Resolution", ResolutionDropdown.value);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}