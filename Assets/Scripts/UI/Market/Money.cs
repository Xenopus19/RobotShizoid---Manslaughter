using UnityEngine.UI;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int MoneyAmount;

    private static Text MoneyText;

    private void Awake()
    {
        MoneyText = GetComponent<Text>();
        GlobalEvents.OnEnemyKilledEvent += AddMoney;
        MoneyAmount = 0;
    }

    public static void SpendMoney(int MoneyToSpend)
    {
        MoneyAmount -= Encrypting.Encrypt(MoneyToSpend);
        UpdateUI();
    }

    private void AddMoney(int EnemyScore)
    {
        int toAdd = Random.Range(0, (5 * EnemyScore) + 1) / 5;
        MoneyAmount += Encrypting.Encrypt(toAdd);
        UpdateUI();
    }

    public static void UpdateUI()
    {
        MoneyText.text = $"{Encrypting.Decipher(MoneyAmount)}";
    }

    private void OnDestroy() 
    {
        GlobalEvents.OnEnemyKilledEvent -= AddMoney;
    }
}
