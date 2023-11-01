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
            if (troopBehavior.GetTroopType() == TroopType.AdditionArcher && troopBehavior.TroopInfo.Damage >= GameManager.Instance.EnemyBaseHealth)
            {
                //Add win yippe
            }
            else if (troopBehavior.GetTroopType() == TroopType.SubtractionSwordsman)
            {
                GameManager.Instance.EnemyBaseHealth -= troopBehavior.TroopInfo.Damage;

                if (GameManager.Instance.EnemyBaseHealth < 1)
                {
                    GameManager.Instance.EnemyBaseHealth = 1;
                }
            }
            else if (troopBehavior.GetTroopType() == TroopType.DivisionDogFighter)
            {
                GameManager.Instance.EnemyBaseHealth = (int) Mathf.Ceil(GameManager.Instance.EnemyBaseHealth /(float) troopBehavior.TroopInfo.Damage);
            }

            Debug.Log(GameManager.Instance.EnemyBaseHealth);
            TroopManager.troops.Remove(troopBehavior);
            Destroy(theObject);
        }
    }
}
