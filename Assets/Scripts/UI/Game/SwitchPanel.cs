using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    public void TurnOffPanel() =>
        gameObject.SetActive(false);
}
