using UnityEngine.UI;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Damage;
    public Sprite Icon;
    public virtual void Attack(Vector3 AttackPosition) { }
}
