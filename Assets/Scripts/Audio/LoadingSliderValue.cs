using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class LoadingSliderValue : MonoBehaviour {
    [SerializeField] private string PrefsKey;

    private Slider Slider;
    void Start() {
        Slider = gameObject.GetComponent<Slider>();

        if (PlayerPrefs.HasKey(PrefsKey)) {
            Slider.value = PlayerPrefs.GetFloat(PrefsKey);
        }
    }
}