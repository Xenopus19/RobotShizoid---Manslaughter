using UnityEngine.UI;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int MoneyAmount;

    private static Text MoneyText;

    private void Start()
    {
        MoneyText = GetComponent<Text>();
        GlobalEventManager.OnEnemyKilledEvent += AddMoney;
    }

    public static void SpendMoney(int MoneyToSpend)
    {
        MoneyAmount -= MoneyToSpend;
        UpdateUI();
    }

    private void AddMoney(int EnemyScore)
    {
        MoneyAmount += EnemyScore * 2;
        UpdateUI();
    }

    private static void UpdateUI()
    {
        MoneyText.text = $"{MoneyAmount}";
    }
}
