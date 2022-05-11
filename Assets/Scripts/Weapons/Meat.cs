using UnityEngine;

public class Meat : MonoBehaviour
{
    [SerializeField] GameObject MeatPrefab;
    [SerializeField] Weapon weapon;
    void Start()
    {
        weapon.OnAttackEnemies += CreateMeat;
    }

    private void CreateMeat()
    {
        //if(weapon.bloodDrive.IsBloodDrive)
            Instantiate(MeatPrefab, transform.position, Quaternion.identity);
    }
}
