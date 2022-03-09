using UnityEngine.UI;
using UnityEngine;

public class MarketButton : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text priceText;

    public void Init(SlotData slotData)
    {
        icon.sprite = slotData.Icon;
        priceText.text = slotData.Price.ToString();
        gameObject.SetActive(true);
    }
}
