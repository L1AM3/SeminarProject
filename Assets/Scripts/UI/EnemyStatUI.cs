using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStatUI : MonoBehaviour
{
    public EnemyBehavior EnemyInformation;

    public TMP_Text EnemyDamageTxt;

    // Update is called once per frame
    void Update()
    {
        EnemyDamageTxt.text = EnemyInformation.EnemyInfo.Damage.ToString();

    }
}
