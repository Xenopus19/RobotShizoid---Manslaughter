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
        Debug.LogWarning($"start mon {MoneyAmount}");
        MoneyAmount = 0;
    }

    public static void SpendMoney(int MoneyToSpend)
    {
        MoneyAmount -= MoneyToSpend;
        UpdateUI();
    }

    private void AddMoney(int EnemyScore)
    {
        MoneyAmount += Random.Range(0, (10 * EnemyScore) + 1) / 10;
        Debug.LogWarning($"add mon {MoneyAmount}");
        UpdateUI();
    }

    public static void UpdateUI()
    {
        Debug.LogWarning($"update mon {MoneyAmount}");
        MoneyText.text = $"{MoneyAmount}";
    }

    private void OnDestroy() 
    {
        GlobalEventManager.OnEnemyKilledEvent -= AddMoney;
    }
}
