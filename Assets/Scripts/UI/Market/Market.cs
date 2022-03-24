using UnityEngine;
using System.Collections;

public struct SlotData
{
    public GameObject Weapon;
    public int Price;
    public Sprite Icon;

    public SlotData(GameObject weapon, int price)
    {
        Weapon = weapon;
        Price = price;
        Icon = weapon.GetComponent<Weapon>().Icon;
    }
}
public class Market : MonoBehaviour
{
    [SerializeField] GameObject[] AllPossibleWeapons;
    [SerializeField] int WavesBeforeMarket;
    [SerializeField] int WeaponSlotsAmount;
    [SerializeField] GameObject MarketButton;

    [SerializeField] GameObject MarketPlane;
    [SerializeField] GameObject QuitButton;
    [SerializeField] Animator _animator;

    private SlotData[] CurrentWeaponSlots;
    private PlayerWeapons playerWeapons;
    private SlotData[] AllPossibletWeaponSlots;

    private void Start()
    {
        EnemySpawn.OnNewWaveStart += TurnOnMarket;
        playerWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapons>();
        FillAllPossibleSlots();
    }

    private void FillAllPossibleSlots()
    {
        AllPossibletWeaponSlots = new SlotData[AllPossibleWeapons.Length];
        for(int i = 0; i<AllPossibleWeapons.Length; i++)
        {
            AllPossibletWeaponSlots[i] = new SlotData(AllPossibleWeapons[i], 1);  //цена-затычка
        }
    }

    private void TurnOnMarket(int WaveNumber)
    {
        if (WaveNumber % WavesBeforeMarket != 0) return;

        _animator.SetBool("IsStarting", true);
        FillCurrentWeaponSlots();
        SetButtons();
    }

    private void FillCurrentWeaponSlots()
    {
        CurrentWeaponSlots = new SlotData[WeaponSlotsAmount];

        for(int i = 0; i<CurrentWeaponSlots.Length; i++)
        {
            CurrentWeaponSlots[i] = AllPossibletWeaponSlots[Random.Range(0, AllPossibletWeaponSlots.Length)];
        }
    }

    private void SetButtons()
    {
        for(int i = 0; i<MarketPlane.transform.childCount; i++)
        {
            MarketPlane.transform.GetChild(i).GetComponent<MarketButton>().Init(CurrentWeaponSlots[i]);
        }
    }

    public void TryBuyWeapon(int WeaponSlotIndex)
    {
        int Price = CurrentWeaponSlots[WeaponSlotIndex].Price;

        if (Money.MoneyAmount < Price) return;

        Money.SpendMoney(Price);
        
        GameObject Weapon = CurrentWeaponSlots[WeaponSlotIndex].Weapon;
        Debug.Log("Bought " + Weapon.name);
        playerWeapons.AddWeapon(Weapon);
    }

    public void TurnOffMarket()
    {
        Time.timeScale = 1;
        _animator.SetBool("IsStarting", false);
    }
    public void StopTime() => Time.timeScale = 0;
}
