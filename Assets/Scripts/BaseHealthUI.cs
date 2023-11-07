using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseHealthUI : MonoBehaviour
{
    public TMP_Text EBaseH;
    public TMP_Text HBaseH;

    // Update is called once per frame
    void Update()
    {
        EBaseH.text = GameManager.Instance.EnemyBaseHealth.ToString();
        HBaseH.text = GameManager.Instance.HomeBaseHealth.ToString();
    }
}
