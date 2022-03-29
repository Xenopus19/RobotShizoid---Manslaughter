using UnityEngine;

public struct SlotData
{
    public GameObject Weapon;
    public int Price;
    public Sprite Icon;

    public SlotData(GameObject weapon)
    {
        Weapon = weapon;
        Weapon weaponData = weapon.GetComponent<Weapon>();
        Price = weaponData.Price;
        Icon = weaponData.Icon;
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
    [SerializeField] GameObject NoMoneyText;
    [SerializeField] GameObject PurchaseText;
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
        for(int i = 0; i < AllPossibleWeapons.Length; i++)
        {
            AllPossibletWeaponSlots[i] = new SlotData(AllPossibleWeapons[i]);  
        }
    }

    private void TurnOnMarket(int WaveNumber)
    {
        if (WaveNumber % WavesBeforeMarket != 0) return;

        PurchaseText.SetActive(false);
        NoMoneyText.SetActive(false);
        _animator.SetBool("IsStarting", true);
        FillCurrentWeaponSlots();
        SetButtons();
    }

    private void FillCurrentWeaponSlots()
    {
        CurrentWeaponSlots = new SlotData[WeaponSlotsAmount];

        for (int i = 0, temp = -1; i < CurrentWeaponSlots.Length; i++)
        {
            int randIndex;
            do 
            {
                randIndex = Random.Range(0, AllPossibletWeaponSlots.Length);
                CurrentWeaponSlots[i] = AllPossibletWeaponSlots[randIndex];
            } while (temp == randIndex);
            temp = randIndex;
        }
    }

    private void SetButtons()
    {
        for (int i = 0; i < MarketPlane.transform.childCount; i++)
        {
            MarketPlane.transform.GetChild(i).GetComponent<MarketButton>().Init(CurrentWeaponSlots[i]);
        }
    }

    public void TryBuyWeapon(int WeaponSlotIndex)
    {
        int Price = CurrentWeaponSlots[WeaponSlotIndex].Price;

        if (Money.MoneyAmount < Price) {
            NoMoneyText.SetActive(true);
            PurchaseText.SetActive(false);
            return;
        }

        Money.SpendMoney(Price);
        
        GameObject Weapon = CurrentWeaponSlots[WeaponSlotIndex].Weapon;
        Debug.Log("Bought " + Weapon.name);
        playerWeapons.AddWeapon(Weapon);
        PurchaseText.SetActive(true);
        NoMoneyText.SetActive(false);
    }

    public void TurnOffMarket()
    {
        Time.timeScale = 1;
        _animator.SetBool("IsStarting", false);
    }
    public void StopTime() => Time.timeScale = 0;
    private void OnDestroy() {
        EnemySpawn.OnNewWaveStart -= TurnOnMarket;
    }
}
