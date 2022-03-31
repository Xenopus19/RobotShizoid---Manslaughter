using UnityEngine;

public class GungnirAchievement : MonoBehaviour {
    [SerializeField] private GameObject Gungnir;
    void Start() {
        if (PlayerPrefs.HasKey("Nakopyl")) {
            Gungnir.SetActive(true);
        }
    }
}
