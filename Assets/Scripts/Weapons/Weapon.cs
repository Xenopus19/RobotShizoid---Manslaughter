using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Damage;
    public virtual void Attack(Vector3 AttackPosition) { }
}
