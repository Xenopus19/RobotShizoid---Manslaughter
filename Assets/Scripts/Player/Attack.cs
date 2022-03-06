using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Затычка чтобы тестить хп
    [SerializeField]  Transform AttackOrigin;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Attacked");
            DoAttack();
        }
    }

    private void DoAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(AttackOrigin.position, 2f);
        foreach(Collider collider in colliders)
        {
            GameObject ColliderObject = collider.gameObject;

            if (ColliderObject.GetComponent<Health>() != null)
                ColliderObject.GetComponent<Health>().GetDamage(5f);
        }
    }
}
