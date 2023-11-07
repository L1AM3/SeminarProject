using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject theObject = collision.gameObject;

        if (theObject.CompareTag("Troop"))
        {
            TroopBehavior troopBehavior = theObject.GetComponent<TroopBehavior>();

        }
    }
}
